from django.conf.urls import patterns, url
from bio import views

urlpatterns = patterns('',
                       url(r'^$', views.bio_detail, name='biodetail'),
                       )
