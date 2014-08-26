from django.shortcuts import render, get_object_or_404
from work.models import Album, Photo

def album_list(request):
    albums = Album.objects.filter(published_date__isnull=False).order_by('-published_date')
    return render(request, 'work/album_list.html', {'albums': albums})  # it searches inside work/templates/work
    # return render(request, 'album_list.html')  # without 'work/' it searches inside work/templates


def album_detail(request, id):
    album = get_object_or_404(Album, published_date__isnull=False, pk=id)
    return render(request, 'work/album_detail.html', {'album': album})  # it searches inside work/templates/work
    # return render(request, 'album_detail.html', {'album': album})  # it searches inside work/templates
