from django.conf.urls import patterns, include, url
from django.contrib import admin
import polls.urls


urlpatterns = patterns('',
    url(r'^$', include(polls.urls, namespace="it_does_not_work_here")),  # or include('polls.urls') <- as string without import
    url(r'^polls/', include('polls.urls', namespace="polls")),  # there is not $ in the regex

    url(r'^admin/', include(admin.site.urls)),
)
