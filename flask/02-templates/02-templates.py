from flask import Flask, render_template, url_for, request
import werkzeug

app = Flask(__name__)


# DEFAULT (URL BUILDING)
@app.route('/')
def show_urls():  # <- url building (django's reverse url)
    # url_for(function) -> returns url
    s = ''
    s += 'url for Hello World => {0}'.format(url_for('hello')) + '<br>'
    s += 'url for Hello "name"> => {0}'.format(url_for('hello', name='john')) + '<br>'
    s += 'url for login => {0}'.format(url_for('login')) + '<br>'
    s += 'url for Add 2 nums => {0}'.format(url_for('add_nums', number1=3, number2=5)) + '<br>'
    s += 'url for file upload => {0}'.format(url_for('upload_file')) + '<br>'
    # s += 'url for Hello "number" => {0}'.format(url_for('hello_number', number=1)) + '<br>'
    # s += 'url for login => {0}'.format(url_for('login')) + '<br>'
    # s += 'url for static => {0}'.format(url_for('static', filename='test.txt')) + '<br>'
    # the "static files" folder is found auto-magically if named [static]
    return s


# it checks username and password
def valid_login(username, password):
    return username == '1' and password == '1'


# LOGIN (POST)
@app.route('/login')
def login():
    error = None
    if request.method == 'POST':
        # To access form data (data transmitted in a POST or PUT request) use the [form] attribute
        if valid_login(request.form['username'], request.form['password']):
            return 'OK'
        else:
            error = 'Invalid username'
    # the code below is executed if the request method
    # was GET or the credentials were invalid
    return render_template('login.html', error=error)


@app.route('/upload', methods=['GET', 'POST'])
def upload_file():
    if request.method == 'POST':
        f = request.files['the_file']
        # f.save('/var/www/uploads/uploaded_file.txt')  # normal flask save
        f.save('/var/www/uploads/' + werkzeug.secure_filename(f.filename))  # save throw werzeug
        return 'upload OK'
    return 'not OK'


# ADD (GET)
@app.route('/add')
def add_nums():
    if request.method == 'GET':
        # To access parameters submitted in the URL (?key=value&another_key=value2)
        # use the args attribute (it always returns string)
        try:
            # must return string
            return str(int(request.args.get('number1', '0')) + int(request.args.get('number2', '0')))
        except ValueError:
            return 'Error in variables'


# HELLO <>
@app.route('/hi/')
@app.route('/hello/<name>')
def hello(name=None):
    return render_template('hello.html', name=name)


if __name__ == '__main__':
    app.run(debug=True)

# Automatic escaping is enabled, so if name contains HTML it will be escaped automatically.
# If you can trust a variable and you know that it will be safe HTML (for example
# because it came from a module that converts wiki markup to HTML) you can mark
# it as safe by using the Markup class or by using the |safe filter in the template.
# Look Jinja 2 documentation for more examples.
#
# Changed in version 0.5: Auto-escaping is no longer enabled for all templates. The
# following extensions for templates trigger auto-escaping: .html, .htm, .xml, .xhtml.
# Templates loaded from a string will have auto-escaping disabled.
