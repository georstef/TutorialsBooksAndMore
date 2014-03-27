from django.conf.urls import patterns, include, url
from django.contrib.auth.decorators import login_required
from polls import views

urlpatterns = patterns('',
    #
    # NORMAL VIEWS
    #
    url(r'^$', views.index, name='index_url_alias'),
    # url(r'^(?P<poll_id>\d+)/$', views.detail, name='detail_url_alias'),
    # url(r'^(?P<poll_id>\d+)/results/$', views.results, name='results_url_alias'),
    # url(r'^(?P<poll_id>\d+)/vote/$', views.vote, name='vote_url_alias'),
    #
    # SAME FUNCTIONALITY BUT WITH GENERIC VIEWS
    #url(r'^$', views.IndexView.as_view(), name='index_url_alias'),
    # generic views require a "pk" argument
    url(r'^(?P<pk>\d+)/$', views.DetailView.as_view(), name='detail_url_alias'),
    # generic views require a "pk" argument
    url(r'^(?P<pk>\d+)/results/$', views.ResultsView.as_view(), name='results_url_alias'),

    #login_required example
    # url(r'^(?P<poll_id>\d+)/vote/$', login_required(views.vote, login_url='/admin/login/'), name='vote_url_alias'),
    url(r'^(?P<poll_id>\d+)/vote/$', views.vote, name='vote_url_alias'),
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
