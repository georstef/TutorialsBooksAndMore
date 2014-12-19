from django.conf.urls import patterns, include, url
from django.contrib.auth.decorators import login_required
from dashboard import views

urlpatterns = patterns('',
    #
    # NORMAL VIEWS
    #
    url(r'^$', views.project_list, name='project_list_url_alias'),
    url(r'^(?P<project_id>\d+)/$', views.project_open, name='project_open_url_alias'),
    # url(r'^(?P<project_id>\d+)/edit/$', views.project_edit, name='project_edit_url_alias'),
    # url(r'^(?P<project_id>\d+)/delete/$', views.project_delete, name='project_delete_url_alias'),
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
