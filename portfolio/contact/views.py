from django.shortcuts import render

def contact_detail(request):
    # album = get_object_or_404(Album, published_date__isnull=False, pk=id)
    return render(request, 'contact/contact_detail.html', {})  # it searches inside contact/templates/contact
    # return render(request, 'work/album_detail.html', {'album': album})  # it searches inside contact/templates
