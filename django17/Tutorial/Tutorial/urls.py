from django.conf.urls import patterns, include, url
from django.contrib import admin
import polls.urls

urlpatterns = patterns('',
    url(r'^$', include(polls.urls)),  # or include('polls.urls') <- as string without import

    url(r'^polls/', include('polls.urls')),  # there is not $ in the regex

    url(r'^admin/', include(admin.site.urls)),
)
