from django.conf.urls import patterns, include, url
from portfolio import views

from django.contrib import admin
admin.autodiscover()


urlpatterns = patterns('',
    url(r'^$', views.index, name='index'),

    url(r'^work/', include('work.urls')),
    url(r'^general/', include('general.urls')),
    url(r'^contact/', include('contact.urls')),
    url(r'^admin/', include(admin.site.urls)),
)
