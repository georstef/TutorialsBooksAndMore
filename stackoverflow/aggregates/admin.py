from django.contrib import admin
from aggregates.models import Match, Team


class MatchAdmin(admin.ModelAdmin):
    list_display = ('team_vs_team_score',)


# Register your models here.
admin.site.register(Match, MatchAdmin)
admin.site.register(Team)