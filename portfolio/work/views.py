from django.shortcuts import render

def album_list(request):
    return render(request, 'album_list.html')  # it searches inside work/templates
    # return render(request, 'work/album_list.html')  # with 'work/' it searches inside work/templates/work
