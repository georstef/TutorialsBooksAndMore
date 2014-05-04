import json
from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, HttpResponseRedirect, Http404
from django.template import RequestContext, loader
from django.core.urlresolvers import reverse
from django.views import generic
from django.contrib.auth.decorators import login_required
from django.core import serializers
from dashboard.models import Project, Task, User, Task_User

# working
def project_list(request):
    # project_list = Project.objects.order_by('id').values('id','title', 'description')
    # project_list = Project.objects.order_by('id').values()
    # return HttpResponse(project_list, content_type ="application/json")
    data = serializers.serialize("json", Project.objects.order_by('id'))
    return HttpResponse(data, content_type ="application/json")



# working
def project_open(request, project_id):
    # project = Project.objects.filter(id=project_id).values()
    # project = Project.objects.filter(id=project_id).values('title', 'task__project_id')
##    if project:
##        return HttpResponse(project, content_type ="application/json")
##    else:
##        return HttpResponse({}, content_type ="application/json")
    data = serializers.serialize("json", Project.objects.filter(id=project_id))
    return HttpResponse(data, content_type ="application/json")

 
