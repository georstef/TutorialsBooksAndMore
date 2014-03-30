from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, HttpResponseRedirect, Http404
from django.template import RequestContext, loader
from django.core.urlresolvers import reverse
from django.views import generic
from django.contrib.auth.decorators import login_required
from django.utils import timezone
import json
from polls.models import Poll, Choice


'''
NORMAL VIEWS
'''
def index(request):
    # first 5 polls with dates not in the future
    latest_poll_list = Poll.objects.filter(pub_date__lte=timezone.now()).order_by('-pub_date')[:5]
    
    #template = loader.get_template('polls/index.html') # load the template
    #context = RequestContext(request, {'latest_poll_list': latest_poll_list}) # create context
    #return HttpResponse(template.render(context))

    # one-liner for the 3 lines above
    return render(request, 'polls/index.html', {'latest_poll_list': latest_poll_list})

    # just ana example of a json response
    #if request.META['HTTP_ACCEPT'] == "application/json":
    #    return HttpResponse(json.dumps({'key1':'value1', 'key2':'value2'}), content_type="application/json")
    #else:
    #    return HttpResponse(json.dumps({'key1':'value1', 'key2':'value2'}), content_type="application/json")


def detail(request, poll_id):
##    try:
##        poll = Poll.objects.get(pk=poll_id)
##    except:
##        raise Http404

    # one-liner for the 4 lines above
    poll = get_object_or_404(Poll, pk=poll_id)
    return render(request, 'polls/detail.html', {'poll': poll})


def results(request, poll_id):
    poll = get_object_or_404(Poll, pk=poll_id)
    return render(request, 'polls/results.html', {'poll':poll})


@login_required#(login_url='/accounts/login/')
def vote(request, poll_id):
    p = get_object_or_404(Poll, pk=poll_id)
    try:
        # request.POST is a dict the values of which are always string
        selected_choice = p.choice_set.get(pk=request.POST['choice_name'])
    except (KeyError, Choice.DoesNotExist):
        return render(request, 'polls/detail.html',
                      {'poll': p,
                       'error_message': "No selection was made"})
    selected_choice.votes += 1
    selected_choice.save()
    # always return an HttpResponseRedirect after succesfully dealing with POST
    # this porevents data from being posted twice if a user hits the back button
    return HttpResponseRedirect(reverse('polls:results_url_alias', args=(p.id,)))

'''
SAME FUNCTIONALITY BUT WITH GENERIC VIEWS
'''
class IndexView(generic.ListView): # display a list of objects
    template_name = 'polls/index.html' # must be named "template_name"
    context_object_name = 'latest_poll_list' # the list is sent under this name

    def get_queryset(self): # the list is taken from "get_queryset"
        """ return the last five published polls not including polls with future dates """
        return Poll.objects.filter(pub_date__lte=timezone.now()).order_by('-pub_date')[:5]      

class DetailView(generic.DetailView): # display a a detail page for a particular object
    model = Poll
    # if "template_name" is left empty it defaults at
    # <app name>/<model name>_detail.html
    # eg-> polls/poll_detail.html
    template_name = 'polls/detail.html'

    def get_queryset(self):
        # don't return polls with future dates
        return Poll.objects.filter(pub_date__lte=timezone.now())

class ResultsView(generic.DetailView):
    model = Poll
    # if "template_name" is left empty it defaults at
    # <app name>/<model name>_detail.html
    # eg-> polls/poll_detail.html
    template_name = 'polls/results.html'

'''
There’s also a get_list_or_404() function, which works
just as get_object_or_404() – except using filter() instead of get().
It raises Http404 if the list is empty.
'''
