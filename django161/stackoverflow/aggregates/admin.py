from django.contrib import admin
from aggregates.models import Match, Team

def reverse_goals(modeladmin, request, queryset):
    for m in queryset:
        m.goals_team_a, m.goals_team_b = m.goals_team_b, m.goals_team_a
        m.save()
reverse_goals.short_description = "Reverse the goals of the match"
    
class MatchAdmin(admin.ModelAdmin):
    list_display = ('team_vs_team_score',)
    actions = [reverse_goals,]


# Register your models here.
admin.site.register(Match, MatchAdmin)
admin.site.register(Team)