from django.conf.urls import patterns, url
from polls import views

urlpatterns = patterns('',
    url(r'^$', views.index, name='index'),  # ex: /polls/ or σκέτο
    url(r'^(?P<question_id>\d+)/$', views.detail, name='detail'),  # ex: /polls/5/
    url(r'^(?P<question_id>\d+)/results/$', views.result, name='results'),  # ex: /polls/5/results/
    url(r'^(?P<question_id>\d+)/vote/$', views.vote, name='vote'),  # ex: /polls/5/vote/
)