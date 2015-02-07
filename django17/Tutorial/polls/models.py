import datetime
from django.db import models
from django.utils import timezone

class Question(models.Model):
    question_text = models.CharField(max_length=200)
    pub_date = models.DateTimeField('date published')  # first positional argument is a human-readable name
    
    def __str__(self):
        return self.question_text
        
    def was_published_recently(self):
        return self.pub_date >= (timezone.now() - datetime.timedelta(days=1))
    # metadata of was_published_recently method for Admin inteface
    was_published_recently.admin_order_field = 'pub_date' # order based on 'pub_date' field since methods cannot be ordered
    was_published_recently.boolean = True  # marks method as boolean and it shows an image instead of True/False text
    was_published_recently.short_description = 'Published recently?'  # grid header
    
class Choice(models.Model):
    question = models.ForeignKey(Question)
    choice_text = models.CharField(max_length=200)
    votes = models.IntegerField(default=0)
    
    def __str__(self):
        return self.choice_text