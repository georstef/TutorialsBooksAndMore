from django.conf.urls import patterns, include, url
from work import views

urlpatterns = patterns('',
    url(r'^$', views.album_list, name='albumlist'),
)
