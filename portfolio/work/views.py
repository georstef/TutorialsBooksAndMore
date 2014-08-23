from django.shortcuts import render
from work.models import Album, Photo

def album_list(request):
    albums = Album.objects.filter(published_date__isnull=False).order_by('-published_date')
    return render(request, 'work/album_list.html', {'albums': albums})  # it searches inside work/templates
    # return render(request, 'work/album_list.html')  # with 'work/' it searches inside work/templates/work
