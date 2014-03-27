from django.contrib import admin
from dashboard.models import Project, Task, User, Task_User

class ProjectAdmin(admin.ModelAdmin):
    # fieldsets => group boxes
    fieldsets = [
        (None, {'fields': ['title', 'description', 'progress']}),
        ('Dates', {'fields': ['start_date', 'end_date']}),
        ]
    list_display = ('title', 'description', 'progress', 'start_date', 'end_date')
    list_filter = ['start_date', 'end_date']
    search_fields = ['title', 'description']

class UserAdmin(admin.ModelAdmin):
    # fieldsets => group boxes
    fieldsets = [
        (None, {'fields': ['name']}),
        ]
    list_display = ('name',)
    search_fields = ['name']

admin.site.register(Project, ProjectAdmin)
admin.site.register(User, UserAdmin)
