from django.db import models

class Project(models.Model):
    title = models.CharField(max_length=200)
    description = models.CharField(max_length=200)
    progress = models.IntegerField(default=0)
    start_date = models.DateTimeField('date started')
    end_date = models.DateTimeField('date ended')

    def __str__(self):
        return self.title


class Task(models.Model):
    title = models.CharField(max_length=200)
    description = models.CharField(max_length=200)
    status = models.CharField(max_length=200)
    project = models.ForeignKey(Project)

    def __str__(self):
        return self.title


class User(models.Model):
    name = models.CharField(max_length=200)

    # for the admin page (where exactly???)
    name.short_description = 'Onoma' 

    def __str__(self):
        return self.name

class Task_User(models.Model):
    task = models.ForeignKey(Task)
    user = models.ForeignKey(User)
