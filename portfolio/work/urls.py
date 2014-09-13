from django.conf.urls import patterns, url
from work import views

urlpatterns = patterns('',
                       url(r'^$', views.album_list, name='albumlist'),
                       url(r'^album/(?P<id>[0-9]+)/$', views.album_detail, name='albumdetail'),
                       )
