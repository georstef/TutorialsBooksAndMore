from django.db import models


MONTH_CHOICES = (
    (1, 'January'),
    (2, 'February'),
    (3, 'March'),
    (4, 'April'),
    (5, 'May'),
    (6, 'June'),
    (7, 'July'),
    (8, 'August'),
    (9, 'September'),
    (10, 'October'),
    (11, 'November'),
    (12, 'December'),
)


class Profile(models.Model):
    full_name = models.CharField(max_length=200)
    address = models.CharField(max_length=100, blank=True, null=True)
    city = models.CharField(max_length=100, blank=True, null=True)
    country = models.CharField(max_length=100, blank=True, null=True)
    telephone = models.CharField(max_length=100, blank=True, null=True)
    mobile = models.CharField(max_length=100, blank=True, null=True)
    email = models.EmailField(max_length=254, blank=True, null=True)

    # text to show on admin page
    def __str__(self):
        return self.full_name


class Experience(models.Model):
    profile = models.ForeignKey(Profile, related_name='experience')
    title = models.CharField(max_length=200)
    company = models.CharField(max_length=200, blank=True, null=True)
    from_month = models.IntegerField(blank=True, null=True, choices=MONTH_CHOICES)
    from_year = models.IntegerField(blank=True, null=True)
    to_month = models.IntegerField(blank=True, null=True, choices=MONTH_CHOICES)
    to_year = models.IntegerField(blank=True, null=True)
    description = models.TextField(blank=True, null=True)

    # text to show on admin page
    def __str__(self):
        return '%s - %s' % (self.company, self.title)


class Education(models.Model):
    profile = models.ForeignKey(Profile, related_name='education')
    degree = models.CharField(max_length=200)
    institution = models.CharField(max_length=200, blank=True, null=True)
    from_year = models.IntegerField(blank=True, null=True)
    to_year = models.IntegerField(blank=True, null=True)
    comments = models.TextField(blank=True, null=True)

    # text to show on admin page
    def __str__(self):
        return '%s - %s' % (self.institution, self.degree)
