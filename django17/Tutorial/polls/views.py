from django.shortcuts import render, get_object_or_404
from django.http import HttpResponseRedirect, HttpResponse, Http404
from django.core.urlresolvers import reverse
from django.views import generic
from django.template import RequestContext, loader
from polls.models import Question, Choice


# -----------------------
# NORMAL VIEWS
# -----------------------
def index(request):
    question_list = Question.objects.order_by('-pub_date')[:5]  # sql -> ORDER BY pub_date desc LIMIT 5
    # output = ', '.join([q.__str__() for q in question_list])  # get the string representation of Question
    # output = ', '.join(map(str, question_list))  # same a above but nicer

    # template = loader.get_template('polls/index.html')
    # context = RequestContext(request, {'question_list': question_list})
    # return HttpResponse(template.render(context))

    return render(request, 'polls/index.html', {'question_list': question_list})  # shortcut for previous 3 lines


def detail(request, question_id):
    # try:
    #     question = Question.objects.get(pk=question_id)
    # except Question.DoesNotExist:
    #     raise Http404('Question does not exists.')
    question = get_object_or_404(Question, pk=question_id)  # shortcut for previous try..except
    return render(request, 'polls/detail.html', {'question': question})  # shortcut for previous 3 lines


def result(request, question_id):
    question = get_object_or_404(Question, pk=question_id)
    return render(request, 'polls/result.html', {'question': question})


def vote(request, question_id):
    question = get_object_or_404(Question, pk=question_id)
    try:
        selected_choice = question.choice_set.get(pk=request.POST['choice'])
    except (KeyError, Choice.DoesNotExist):
        return render(request, 'polls/detail.html', {'question': question, 'error_message': 'Please make a choice'})

    selected_choice.votes += 1
    selected_choice.save()
    # return HttpResponseRedirect(reverse('polls:results', args=(question_id,)))
    return HttpResponseRedirect(reverse('polls:results', args=(question_id,)))


# -----------------------
# GENERIC VIEWS
# -----------------------
class IndexView(generic.ListView):
    template_name = 'polls/index.html'  # by default is <app name>/<model name>_list.html
    context_object_name = 'question_list'  # by default is <model name>_list

    def get_queryset(self):
        return Question.objects.order_by('-pub_date')[:5]


class DetailView(generic.DetailView):
    template_name = 'polls/detail.html'  # by default is <app name>/<model name>_detail.html
    model = Question
    context_object_name = 'question'  # by default is <model name>


class ResultView(generic.DetailView):
    template_name = 'polls/result.html'  # by default is <app name>/<model name>_detail.html
    model = Question
