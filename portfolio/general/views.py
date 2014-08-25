from django.shortcuts import render
# from general.models import Contact, Bio

def bio_detail(request):
    # albums = Album.objects.filter(published_date__isnull=False).order_by('-published_date')
    return render(request, 'general/bio_detail.html', {})  # it searches inside work/templates/work
    # return render(request, 'album_list.html')  # with 'work/' it searches inside work/templates


def contact_detail(request):
    # album = get_object_or_404(Album, published_date__isnull=False, pk=id)
    return render(request, 'general/contact_detail.html', {})  # it searches inside work/templates/work
    # return render(request, 'work/album_detail.html', {'album': album})  # it searches inside work/templates
