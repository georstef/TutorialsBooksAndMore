from smtplib import SMTPException
from django.shortcuts import render
from django.core.mail import send_mail, BadHeaderError
from django.contrib import messages
from contact.models import Contact


def contact_detail(request):
    if request.method == 'POST':
        name = request.POST.get('name', '')
        email = request.POST.get('email', '')
        message = request.POST.get('message', '')

        if name and email and message:
            try:
                send_mail('message from {0}'.format(name), message, email, ['georstef@gmail.com'])
                messages.success(request, 'Το μήνυμά σας στάλθηκε.')
            except BadHeaderError:
                messages.error(request, 'Παρουσιάστηκε σφάλμα κατά την αποστολή του μηνύματος.')
            except SMTPException:
                messages.error(request, 'Παρουσιάστηκε σφάλμα κατά την αποστολή του μηνύματος.')

    # request.GET
    contacts = Contact.objects.all()
    return render(request, 'contact/contact.html', {'contacts': contacts})
