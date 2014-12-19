from django.contrib import admin
from django_summernote.admin import SummernoteModelAdmin
from bio.models import *


class ExperienceAdmin(SummernoteModelAdmin):
    pass


class EducationAdmin(SummernoteModelAdmin):
    pass


admin.site.register(Profile)
admin.site.register(Experience, ExperienceAdmin)
admin.site.register(Education, EducationAdmin)
