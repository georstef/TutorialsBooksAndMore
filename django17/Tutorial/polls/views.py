from django.shortcuts import render
from django.http import HttpResponse
from polls.models import Question

def index(request):
    question_list = Question.objects.order_by('-pub_date')[:5]  # sql -> ORDER BY pub_date desc LIMIT 5
    output = ', '.join([q.__str__() for q in question_list])
    return HttpResponse(output)


def detail(request, question_id):
    return HttpResponse('detail %s' % question_id)


def result(request, question_id):
    return HttpResponse('result %s' % question_id)


def vote(request, question_id):
    return HttpResponse('vote %s' % question_id)
