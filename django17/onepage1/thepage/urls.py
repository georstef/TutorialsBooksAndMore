from django.conf.urls import patterns, url
from thepage import views

urlpatterns = patterns('',
                       url(r'^$', views.index, name='index'),
                       )
