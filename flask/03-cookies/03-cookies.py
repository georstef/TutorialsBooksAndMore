from flask import Flask, render_template, url_for, make_response, request, redirect, abort
app = Flask(__name__)


# DEFAULT (URL BUILDING)
@app.route('/')
def show_urls():  # <- url building (django's reverse url)
    # url_for(function) -> returns url
    s = ''
    s += 'url for show urls => {0}'.format(url_for('show_urls')) + '<br>'
    s += 'url for show cookie => {0}'.format(url_for('cookie')) + '<br>'
    s += 'url for redirect => {0}'.format(url_for('redirect_to_cookie')) + '<br>'
    s += 'url for abort => {0}'.format(url_for('abort_example', status=401)) + '<br>'
    return s


# COOKIES
@app.route('/cookie/')
def cookie():
    # *** how to get a cookie ***
    # use cookies.get(key) instead of cookies[key] to not get a KeyError if the cookie is missing.
    username = request.cookies.get('username')

    # just toggle between john and empty_str
    if username:
        username = ''  # if username exists it sets it to emtpy_str
    else:
        username = 'John'  # if username is none it sets it to John

    # *** how to set a cookie ***
    resp = make_response(render_template('hello.html', name=username))
    resp.set_cookie('username', username)  # the cookie is attached to a [response]
    return resp


# COOK (redirect)
@app.route('/cook/')
def redirect_to_cookie():
    return redirect(url_for('cookie'))


# ABORT
@app.route('/coo/<status>')
def abort_example(status):
    abort(int(status))


@app.errorhandler(404)  # this is an error handler for custom error pages for the error 404
def page_not_found(error):
    # return render_template('page_not_found.html'), 404  # for custom error pages
    # return error  # the [error] parameter is already a response object
    # example of a "response" wrapping the follows
    resp = make_response(error)
    resp.headers['X-Something'] = 'A value'
    return resp, 401  # we wrap the response object and change the error code (logic 3-tuple, see bottom)


if __name__ == '__main__':
    app.run(debug=True)

# a) The return value from a view function is automatically converted into a response object.
#
# b) If the return value is a string it’s converted into a response object with the
#    string as response body, a 200 OK status code and a text/html mime-type.
#
# The logic that Flask applies to converting return values into response objects is as follows:
#   1. If a response object of the correct type is returned it’s directly returned from the view.
#   2. If it’s a string, a response object is created with that data and the default parameters.
#   3. If a tuple is returned the items in the tuple can provide extra information.
#      Such tuples have to be in the form (response, status, headers) or (response,
#      headers) where at least one item has to be in the tuple. The status value will override
#      the status code and headers can be a list or dictionary of additional header values.
#   4. If none of that works, Flask will assume the return value is a valid WSGI application
#      and convert that into a response object.