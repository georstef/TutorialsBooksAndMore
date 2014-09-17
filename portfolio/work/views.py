from django.shortcuts import render, get_object_or_404
from django.core.paginator import Paginator, EmptyPage, PageNotAnInteger
from work.models import Album, Photo


def album_list(request):
    albums_list = Album.objects.filter(published_date__isnull=False, photo__isnull=False).distinct().order_by('-published_date')
    paginator = Paginator(albums_list, 2)

    page = request.GET.get('page')
    try:
        albums = paginator.page(page)
    except PageNotAnInteger:
        # if page is not an integer, deliver first page.
        albums = paginator.page(1)
    except EmptyPage:
        # if page is out of range (e.g. 9999), deliver last page of results.
        albums = paginator.page(paginator.num_pages)
    return render(request, 'work/album_list.html', {'albums': albums})  # it searches inside work/templates/work
    # return render(request, 'album_list.html')  # without 'work/' it searches inside work/templates


def album_detail(request, id):
    album = get_object_or_404(Album, published_date__isnull=False, pk=id)
    return render(request, 'work/album_detail.html', {'album': album})  # it searches inside work/templates/work
    # return render(request, 'album_detail.html', {'album': album})  # it searches inside work/templates
