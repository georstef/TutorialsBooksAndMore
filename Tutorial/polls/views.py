from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, Http404
from django.template import RequestContext, loader
from polls.models import Poll

def index(request):
    latest_poll_list = Poll.objects.order_by('-pub_date')[:5]
    
    #template = loader.get_template('polls/index.html') # load the template
    #context = RequestContext(request, {'latest_poll_list': latest_poll_list}) # create context
    #return HttpResponse(template.render(context))

    # one-liner for the 3 lines above 
    return render(request, 'polls/index.html', {'latest_poll_list': latest_poll_list})

def detail(request, poll_id):
##    try:
##        poll = Poll.objects.get(pk=poll_id)
##    except:
##        raise Http404

    # one-liner for the 4 lines above
    poll = get_object_or_404(Poll, pk=poll_id)
    return render(request, 'polls/detail.html', {'poll': poll})

def results(request, poll_id):
    return HttpResponse('results of poll id %s.' % poll_id)

def vote(request, poll_id):
    return HttpResponse('voting for poll id %s.' % poll_id)

'''
There’s also a get_list_or_404() function, which works
just as get_object_or_404() – except using filter() instead of get().
It raises Http404 if the list is empty.
'''
