from django.shortcuts import render
from aggregates.models import Team


def index(request):
    return render(request, 'index.html')


def aggregate(request):
    teams = Team.objects.order_by('id')
    return render(request, 'goals_aggregate.html', {'teams': teams})


def annotate(request):
    teams = Team.objects.order_by('id')
    return render(request, 'goals_annotate.html', {'teams': teams})


def sql(request):
    teams = Team.objects.order_by('id')
    return render(request, 'goals_sql.html', {'teams': teams})


def extra(request):
    teams = Team.objects.order_by('id')
    return render(request, 'goals_extra.html', {'teams': teams})
