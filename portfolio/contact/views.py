from django.shortcuts import render
from django.core.mail import send_mail, BadHeaderError
from contact.models import Contact


def contact_detail(request):
    if request.method == 'POST':
        name = request.POST.get('name', '')
        email = request.POST.get('email', '')
        message = request.POST.get('message', '')

        if name and email and message:
            return render(request, 'contact/yes.html')
            try:
                send_mail(name, message, email, ['georstef@gmail.com'])
            except BadHeaderError:
                return render(request, 'contact/no.html')
                # return HttpResponse('Invalid header found.')

            return render(request, 'contact/yes.html')
            # return HttpResponseRedirect('/contact/thankyou/')
            pass  # alert
    # request.GET
    contacts = Contact.objects.all()
    return render(request, 'contact/contact.html', {'contacts': contacts})
