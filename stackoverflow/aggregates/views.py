from django.shortcuts import render


def index(request):
    return render(request, 'index.html')


def aggregate(request):
    return render(request, 'goals.html', {'team': 'test', 'goals_for': 10, 'goals_against': 8})


def annotate(request):
    return render(request, 'goals.html', {'team': 'test', 'goals_for': 10, 'goals_against': 8})


def sql(request):
    return render(request, 'goals.html', {'team': 'test', 'goals_for': 10, 'goals_against': 8})
