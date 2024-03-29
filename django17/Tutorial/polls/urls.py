from django.conf.urls import patterns, url
from polls import views


urlpatterns = patterns('',
    # GENERIC VIEWS (note->regex variable renamed pk)
    url(r'^$', views.IndexView.as_view(), name='index'),  # ex: /polls/ or σκέτο
    url(r'^(?P<pk>\d+)/$', views.DetailView.as_view(), name='detail'),  # ex: /polls/5/
    url(r'^(?P<pk>\d+)/results/$', views.ResultView.as_view(), name='results'),  # ex: /polls/5/results/

    # NORMAL VIEWS
    # url(r'^$', views.index, name='index'),  # ex: /polls/ or σκέτο
    # url(r'^(?P<question_id>\d+)/$', views.detail, name='detail'),  # ex: /polls/5/
    # url(r'^(?P<question_id>\d+)/results/$', views.result, name='results'),  # ex: /polls/5/results/
    url(r'^(?P<question_id>\d+)/vote/$', views.vote, name='vote'),  # ex: /polls/5/vote/
)
