from django.conf.urls import patterns, include, url
from aggregates.views import index, aggregate, annotate, sql, extra

urlpatterns = patterns('',
    url(r'^$', index, name='index_url_alias'),
    url(r'^aggregate/', aggregate, name='aggregate_url_alias'),
    url(r'^annotate/', annotate, name='annotate_url_alias'),
    url(r'^sql/', sql, name='sql_url_alias'),
    url(r'^extra/', extra, name='extra_url_alias'),
)
