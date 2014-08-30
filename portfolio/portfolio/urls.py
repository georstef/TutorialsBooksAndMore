from django.conf.urls import patterns, include, url
from django.conf.urls.static import static
from portfolio import settings
from portfolio import views

from django.contrib import admin
admin.autodiscover()


urlpatterns = patterns('',
    url(r'^$', views.index, name='index'),

    url(r'^work/', include('work.urls')),
    url(r'^bio/', include('bio.urls')),
    url(r'^contact/', include('contact.urls')),
    url(r'^admin/', include(admin.site.urls)),
)

urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)