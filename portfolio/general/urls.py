from django.conf.urls import patterns, url
from general import views

urlpatterns = patterns('',
                       url(r'^bio$', views.bio_detail, name='biodetail'),
                       )
