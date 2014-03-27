from django.conf.urls import patterns, include, url

from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'Tutorial.views.home', name='home'),

    # namespace is an argument of the "include" function
    url(r'^polls/', include('polls.urls', namespace='polls')), 

    url(r'^admin/', include(admin.site.urls)),
    url(r'^accounts/login/$', 'django.contrib.auth.views.login'),
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
