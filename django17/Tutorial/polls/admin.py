from django.contrib import admin
from polls.models import Question, Choice  # this must be added

admin.site.register(Choice)  # simple way of registering a table to admin


# class for detail table Choice (to help show it in Question form - Stacked meaning like a form)
class ChoiceInlineStacked(admin.StackedInline):
    model = Choice
    extra = 0  # how many Choice records to show by default
    

# class for detail table Choice (to help show it in Question form - Tabular meaning like a grid)
class ChoiceInlineTabular(admin.TabularInline):
    model = Choice
    exclude = ['votes'] # to hide specific fields
    extra = 0  # how many Choice records to show by default

    
# admin object
class QuestionAdmin(admin.ModelAdmin):
    list_display = ('question_text', 'pub_date', 'was_published_recently')  # select and order the fields in the grid
    # fields = ['pub_date', 'question_text']  # change the order the fields appear in form (no grouping)
    fieldsets = [
        (None,               {'fields': ['question_text']}),  # group without name
        ('Date information', {'fields': ['pub_date']}),  # group named Date information
        # ('Date information', {'fields': ['pub_date'], 'classes': ['collapse']}),  # group named Date information starting collapsed
    ]
    inlines = [ChoiceInlineTabular]  # adds Choices table Stacked or Tabular or both
    list_filter = ['question_text', 'pub_date']  # add predefined filters for fields 'question_text' and 'pub_date'
    search_fields = ['question_text', 'choice__choice_text'] # adds ONE search filter for field 'question_text' and detail table field 'choice__choice_text'
    list_per_page  = 2  # pagination for grid, default is 100 records

admin.site.register(Question ,QuestionAdmin)  # register a table with an admin object ()


