from flask import Flask, session, redirect, url_for, escape, request
import logging
from logging.handlers import RotatingFileHandler

app = Flask(__name__)


# COOKIES
@app.route('/')
def index():
    app.logger.info('A value for INFO')
    if 'username' in session:
        return 'logged in as ' + escape(session['username'])  # escape for html injections
    return 'not logged in'


# HTTP METHODS
@app.route('/login', methods=['GET', 'POST'])  # route only answers to GET and POST
def login():
    if request.method == 'POST':
        # Flask will take the values you put into the session object and serialize them into a cookie
        session['username'] = request.form['username']
        return redirect(url_for('index'))
    return '''
        <form action="" method="post">
            <p><input type=text name=username>
            <p><input type=submit value=Login>
        </form>
        '''


# SESSION (a second object implemented on top of cookies)
@app.route('/logout/')
def logout():
    session.pop('username', None)  # remove the username from the session
    return redirect(url_for('index'))


if __name__ == '__main__':
    handler = RotatingFileHandler('04-sessions.log', maxBytes=10000, backupCount=1)
    # handler.setLevel(logging.INFO)  # set the desired logging level here (also works)
    app.logger.setLevel(logging.INFO)  # set the desired logging level here (this works better)
    app.logger.addHandler(handler)

    # import os
    # app.secret_key = os.urandom(24)  # use this for creating a really random key and saving it to a db
    app.secret_key = 'A0Zr98j/3yX R~XHH!jmN]LWX/,?RT'  # for encryption and decryption need the same key
    app.run(debug=True)
