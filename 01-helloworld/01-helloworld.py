from flask import Flask, url_for, request
app = Flask(__name__)


# HELLO
@app.route('/hello/')
def hello_world():
    return 'Hello World!'


# PARAMETER
@app.route('/user/<username>')  # <- with trailing slash
def hello_user(username):
    return 'Hello ' + username


# RULED PARAMETER
@app.route('/num/<int:number>')  # <- if number is not a int it return 404
def hello_number(number):
    return 'Hello number ' + str(number)


# DEFAULT URL BUILDING
@app.route('/')
def show_urls():  # <- url building (django's reverse url)
    # url_for(function) -> returns url
    s = ''
    s += 'url for Hello World => {0}'.format(url_for('hello_world')) + '<br>'
    s += 'url for Hello "user"> => {0}'.format(url_for('hello_user', username='a_name')) + '<br>'
    s += 'url for Hello "user" => {0} [not implemented just an example for params]'.format(
        url_for('hello_user', username='a_name', param1='john', other='george')) + '<br>'
    s += 'url for Hello "number" => {0}'.format(url_for('hello_number', number=1)) + '<br>'
    s += 'url for login => {0}'.format(url_for('login')) + '<br>'
    s += 'url for static => {0}'.format(url_for('static', filename='test.txt')) + '<br>'
    # the "static files" folder is found auto-magically if named [static]
    return s


# HTTP METHODS
@app.route('/login', methods=['GET', 'POST'])  # route only answers to GET and POST
def login():
    if request.method == 'POST':
        return "do_the_login (%s)" % request.method
    else:
        return "show_the_login_form (%s)" % request.method

if __name__ == '__main__':
    app.debug = True  # for auto-reload it can also be a one-liner
    app.run()         # or app.run(debug = True)
