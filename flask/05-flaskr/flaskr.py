import sqlite3
import os
from flask import Flask, request, session, g, redirect, url_for, \
    abort, render_template, flash


app = Flask(__name__)
app.config.from_object(__name__)

# app.config is a dict with the keys being strings with CAPITAL letters
app.config.update(dict(
    DATABASE=os.path.join(app.root_path, 'flaskr.db'),
    DEBUG=True,
    SECRET_KEY='dev_key',
    USERNAME='1',
    PASSWORD='1'
))
app.config.from_envvar('FLASKR_SETTINGS', silent=True)


def connect_db():
    """ connects to specific database """
    rv = sqlite3.connect(app.config['DATABASE'])
    rv.row_factory = sqlite3.Row
    return rv


def get_db():
    """
    opens a new database connection
    if there is none for the current application context
    ------------------------
    g: is a general purpose variable for the current application context
    request: is the request object associated with the current request
    """
    if not hasattr(g, 'sqlite_db'):
        g.sqlite_db = connect_db()  # add an attribute/property to the object g
    return g.sqlite_db


# Functions marked with teardown_appcontext() are called every time the app context tears down.
# So what does this mean? Essentially the app context is created before
# the request comes in and is destroyed (teared down) whenever the request finishes.
# A teardown can happen because of two reasons:
# 1) either everything went well (the error parameter will be None) or
# 2) an exception happened in which case the error is passed to the teardown function.
@app.teardown_appcontext
def close_db(error):
    """ closes the database at the end of the request """
    if error:
        pass
    if not hasattr(g, 'sqlite_db'):
        g.sqlite_db.close()


def init_db():
    # here we create the application context
    with app.app_context():
        db = get_db()
        with app.open_resource('schema.sql', mode='r') as f:
            db.cursor().executescript(f.read())
        db.commit()


@app.route('/')
def show_entries():
    db = get_db()
    cur = db.execute('select title, post from entries order by id desc')
    entries = cur.fetchall()
    return render_template('show_entries.html', entries=entries)


@app.route('/add', methods=['POST'])
def add_entry():
    if not session.get('logged_in'):
        abort(401)
    db = get_db()
    db.execute('insert into entries (title, post) values (?, ?)',
               [request.form['title'], request.form['post']])
    db.commit()
    flash('now entry added')
    return redirect(url_for('show_entries'))


@app.route('/login', methods=['GET', 'POST'])
def login():
    error = None
    if request.method == 'POST':
        if request.form['username'] != app.config['USERNAME']:
            error = 'Invalid username'
        elif request.form['password'] != app.config['PASSWORD']:
            error = 'Invalid password'
        else:
            session['logged_in'] = True
            flash('you are logged in')
            return redirect(url_for('show_entries'))
    return render_template('login.html', error=error)


@app.route('/logout')
def logout():
    session.pop('logged_in', None)
    flash('you logged out')
    return redirect(url_for('show_entries'))


if __name__ == '__main__':
    app.run()