from django.shortcuts import render
from bio.models import *


def bio_detail(request):
    profiles = Profile.objects.all()
    return render(request, 'bio/bio_detail.html', {'profiles': profiles})  # it searches inside bio/templates/bio