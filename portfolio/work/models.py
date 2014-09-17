from django.db import models
from django.utils import timezone
from django.contrib.auth.models import User


class Album(models.Model):
    title = models.CharField(max_length=100)
    description = models.TextField(blank=True, null=True)
    created_date = models.DateTimeField(default=timezone.now())
    published_date = models.DateTimeField(blank=True, null=True)
    user = models.ForeignKey(User, related_name='album')

    def publish(self):
        self.published_date = timezone.now()
        self.save()

    def get_cover_photo(self):
        cover_photo = self.photo.filter(use_as_cover=True)[0]
        if cover_photo:
            return cover_photo
        else:
            return self.photo.all[0]

    def has_photo(self):
        return self.photo.exists()

    # text to show on admin page
    def __str__(self):
        return self.title


def get_image_path(instance, filename):
    # if not instance.id:
    #    instance.save()     <- this causes recursion
    # return 'media_folder/%s/%s' % (instance.album_id, filename)
    return '%s/%s' % (instance.album_id, filename)


class Photo(models.Model):
    album = models.ForeignKey(Album, related_name='photo')
    title = models.CharField(max_length=100)
    description = models.TextField(blank=True, null=True)
    image = models.ImageField(upload_to=get_image_path, blank=True, null=True)
    # image = models.FileField(
    #     upload_to=lambda instance, filename: '%s/%s-%s.jpg' % (instance.album_id, instance.id, filename))
    use_as_cover = models.BooleanField(default=False, null=False)
    created_date = models.DateTimeField(default=timezone.now())

    # text to show on admin page
    def __str__(self):
        return self.title