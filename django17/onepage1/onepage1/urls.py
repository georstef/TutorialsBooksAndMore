from django.conf.urls import patterns, include, url
from django.contrib import admin

urlpatterns = patterns('',
    url(r'^$', include('thepage.urls', namespace="thepage")),
    url(r'^admin/', include(admin.site.urls)),
)