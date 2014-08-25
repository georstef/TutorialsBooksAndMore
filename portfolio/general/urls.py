from django.conf.urls import patterns, url
from general import views

urlpatterns = patterns('',
                       url(r'^bio$', views.bio_detail, name='biodetail'),
                       url(r'^contact$', views.contact_detail, name='contactdetail'),
                       )
