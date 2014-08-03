from django.db import models


# Create your models here.
class Match(models.Model):
    team_a = models.ForeignKey("Team", related_name="team_a")
    team_b = models.ForeignKey("Team", related_name="team_b")
    goals_team_a = models.IntegerField(default=0)
    goals_team_b = models.IntegerField(default=0)
    winner_team = models.ForeignKey("Team", related_name="winner_team", null=True)
    # match_type = models.CharField(choices=match_type_choices, max_length=100, null=False)
    match_played = models.BooleanField(default=False)
    date = models.DateField()

    def __str__(self):
        return self.team_vs_team()

    def team_vs_team(self):
        return self.team_a.name + ' vs ' + self.team_b.name

    def team_vs_team_score(self):
        return '{0} vs {1} ({2}-{3})'.format(self.team_a.name, self.team_b.name, self.goals_team_a, self.goals_team_b)
    team_vs_team_score.short_description = 'Match'  # the header of the column in the grid in admin console


class Team(models.Model):
    name = models.CharField(max_length=200)
    # group = models.CharField(choices=group_choices, max_length=1, null=False)
    matches_played = models.IntegerField(default=0)
    matches_won = models.IntegerField(default=0)
    matches_lost = models.IntegerField(default=0)
    matches_tied = models.IntegerField(default=0)
    goals_in_favor = models.IntegerField(default=0)
    goals_against = models.IntegerField(default=0)
    points = models.IntegerField(default=0)
    url_flag = models.CharField(max_length=500)

    def __str__(self):
        return self.name