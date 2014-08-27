from django.conf.urls import patterns, url
from django.contrib.staticfiles.urls import staticfiles_urlpatterns
from work import views

urlpatterns = patterns('',
                       url(r'^$', views.album_list, name='albumlist'),
                       url(r'^album/(?P<id>[0-9]+)/$', views.album_detail, name='albumdetail'),
                       )

# urlpatterns += staticfiles_urlpatterns()
