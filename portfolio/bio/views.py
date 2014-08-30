from django.shortcuts import render
# from general.models import Contact, Bio

def bio_detail(request):
    # albums = Album.objects.filter(published_date__isnull=False).order_by('-published_date')
    return render(request, 'bio/bio_detail.html', {})  # it searches inside work/templates/work
    # return render(request, 'album_list.html')  # with 'work/' it searches inside work/templates
