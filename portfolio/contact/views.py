from django.shortcuts import render
from contact.models import Contact


def contact_detail(request):
    contacts = Contact.objects.all()
    return render(request, 'contact/contact.html', {'contacts': contacts})
