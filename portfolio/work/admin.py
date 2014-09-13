from django.contrib import admin
from django_summernote.admin import SummernoteModelAdmin
from work.models import Album, Photo


class AlbumAdmin(SummernoteModelAdmin):
    # exclude = ('user',) # must be excluded to be able to change or form parameter must be used
    # override save_model() method
    def save_model(self, request, obj, form, change):
        # change=True means that we are editing an existing record
        # change=False means that we are inserting a new record
        if not change:
            # must be excluded to be able to change or form parameter must be used (somehow)
            obj.user_id = request.user.id  # this will only run on insert
        obj.save()


admin.site.register(Album, AlbumAdmin)
admin.site.register(Photo)
