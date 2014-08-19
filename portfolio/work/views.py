from django.shortcuts import render

def album_list(request):
    return render(request, 'album_list.html')
