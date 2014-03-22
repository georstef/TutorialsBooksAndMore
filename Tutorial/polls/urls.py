from django.conf.urls import patterns, include, url
from polls import views

urlpatterns = patterns('',
    # Examples:
    url(r'^$', views.index, name='index_url_alias'),
    url(r'^(?P<poll_id>\d+)/$', views.detail, name='detail_url_alias'),
    url(r'^(?P<poll_id>\d+)/results/$', views.detail, name='results_url_alias'),
    url(r'^(?P<poll_id>\d+)/vote/$', views.detail, name='vote_url_alias'),
)

'''
The url() function is passed four arguments:
required:
    regex: a regular expression matching url patterns
           it does not match GET/POST parameters or domain name
           in a request to http://www.example.com/myapp/?page=3
           the URLconf will look for myapp/

    view: when a regex is matched it calls the specified view function
          with an HttpRequest as a first argument and
          other "captured" values (from the regex) as other arguments
optional:
    kwargs: ???
    name: it names the url
'''
