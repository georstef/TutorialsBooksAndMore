from django.db import models
import datetime
from django.utils import timezone

class Poll(models.Model):
    question = models.CharField(max_length=200)
    pub_date = models.DateTimeField('date published')
    # pub_date -> machine-readable name (field name)
    # date published -> positional argument human-readable name (description)

    def was_published_recently(self):
        # must be smaller than NOW and bigger than NOW-1
        return timezone.now() > self.pub_date >= timezone.now() - datetime.timedelta(days=1)
    
    # extra stuff for the admin site
    was_published_recently.admin_order_field = 'pub_date' # allows sorting based on another field
    was_published_recently.boolean = True #True shows icons, False shows text
    was_published_recently.short_description = 'Header for admin site'
    
    def __str__(self):
        return self.question


class Choice(models.Model):
    poll = models.ForeignKey(Poll)
    choice_text = models.CharField(max_length=200)
    votes = models.IntegerField(default=0)

    def __str__(self):  
        return self.choice_text
    
