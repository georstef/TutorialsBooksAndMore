from django.contrib import admin
from polls.models import Poll, Choice


# class ChoiceInline(admin.StackedInline): # fields one under the other
class ChoiceInline(admin.TabularInline):   # fields side by side
    model = Choice
    extra = 3


class PollAdmin(admin.ModelAdmin):
    # only one can be set (fields or fieldsets)
    # fields = ['pub_date', 'question']
    fieldsets = [
        (None, {'fields': ['question']}),
        ('Date information', {'fields': ['pub_date'], 'classes':['collapse']}),
        ]
    inlines = [ChoiceInline]
    # columns to display in the list page of the table
    list_display = ('question', 'pub_date', 'was_published_recently')
    # adds filters in the list page of the table
    list_filter = ['pub_date']
    search_fields = ['question']
    
# Register your models here.
admin.site.register(Poll, PollAdmin)

