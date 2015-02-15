from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, Http404
from django.template import RequestContext, loader
from polls.models import Question

def index(request):
    question_list = Question.objects.order_by('-pub_date')[:5]  # sql -> ORDER BY pub_date desc LIMIT 5
    # output = ', '.join([q.__str__() for q in question_list])  # get the string representation of Question
    # output = ', '.join(map(str, question_list))  # same a above but nicer

    # template = loader.get_template('polls/index.html')
    # context = RequestContext(request, {'question_list': question_list})
    # return HttpResponse(template.render(context))

    return render(request, 'polls/index.html', {'question_list': question_list})  # shortcut for previous 3 lines


def detail(request, question_id):
    try:
        question = Question.objects.get(pk=question_id)
    except Question.DoesNotExist:
        raise Http404('Question does not exists.')

    question = get_object_or_404(Question, pk=question_id)  # shortcut for previous try..except
    return render(request, 'polls/detail.html', {'question': question})  # shortcut for previous 3 lines


def result(request, question_id):
    return HttpResponse('result %s' % question_id)


def vote(request, question_id):
    return HttpResponse('vote %s' % question_id)
