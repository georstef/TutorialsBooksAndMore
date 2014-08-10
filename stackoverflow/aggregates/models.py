from django.db import models
from django.db.models import Sum


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
    goals_agaiinst = models.IntegerField(default=0)
    points = models.IntegerField(default=0)
    url_flag = models.CharField(max_length=500)

    def __str__(self):
        return self.name

    def aggregate_total_goals_for(self):
        # aggregate returns a dictionary
        as_teama = Match.objects.filter(team_a_id=self.id).aggregate(Sum('goals_team_a'))
        goals_as_teama = as_teama['goals_team_a__sum'] if as_teama['goals_team_a__sum'] else 0

        as_teamb = Match.objects.filter(team_b_id=self.id).aggregate(Sum('goals_team_b'))
        goals_as_teamb = as_teamb['goals_team_b__sum'] if as_teamb['goals_team_b__sum'] else 0

        return goals_as_teama + goals_as_teamb

    def aggregate_total_goals_against(self):
        # aggregate returns a dictionary
        of_teama = Match.objects.filter(team_b_id=self.id).aggregate(Sum('goals_team_a'))
        goals_of_teama = of_teama['goals_team_a__sum'] if of_teama['goals_team_a__sum'] else 0

        of_teamb = Match.objects.filter(team_a_id=self.id).aggregate(Sum('goals_team_b'))
        goals_of_teamb = of_teamb['goals_team_b__sum'] if of_teamb['goals_team_b__sum'] else 0

        return goals_of_teama + goals_of_teamb

    def annotate_total_goals_for(self):
        # annotate returns a queryset
        as_teama = Team.objects.filter(id=self.id).annotate(goals_teama=Sum('team_a__goals_team_a'))
        goals_as_teama = as_teama[0].goals_teama if as_teama else 0

        as_teamb = Team.objects.filter(id=self.id).annotate(goals_teamb=Sum('team_b__goals_team_b'))
        goals_as_teamb = as_teamb[0].goals_teamb if as_teamb else 0

        return int(goals_as_teama or 0) + int(goals_as_teamb or 0)

    def annotate_total_goals_against(self):
        # annotate returns a queryset
        # of_team = Team.objects.filter(id=self.id).annotate(goals_teama=Sum('team_b__goals_team_a'), goals_teamb=Sum('team_a__goals_team_b'))
        # goals_of_teama = of_team[0].goals_teama if of_team else 0
        # goals_of_teamb = of_team[0].goals_teamb if of_team else 0

        of_teama = Team.objects.filter(id=self.id).annotate(goals_teama=Sum('team_b__goals_team_a'))
        goals_of_teama = of_teama[0].goals_teama if of_teama else 0

        of_teamb = Team.objects.filter(id=self.id).annotate(goals_teamb=Sum('team_a__goals_team_b'))
        goals_of_teamb = of_teamb[0].goals_teamb if of_teamb else 0

        return int(goals_of_teama or 0) + int(goals_of_teamb or 0)

    def sql_total_goals(self):
        # sql returns a cursor (fetchall()=list of tuples, fetchone()=tuple)
        from django.db import connection
        cursor = connection.cursor()
        cursor.execute('''
          select
            Ifnull((select sum(goals_team_a) from aggregates_match where team_a_id = aggregates_team.id), 0) +
            Ifnull((select sum(goals_team_b) from aggregates_match where team_b_id = aggregates_team.id), 0) goals_for,
            Ifnull((select sum(goals_team_b) from aggregates_match where team_a_id = aggregates_team.id), 0) +
            Ifnull((select sum(goals_team_a) from aggregates_match where team_b_id = aggregates_team.id), 0) goals_against
          from aggregates_team
          where id = %s
          ''', [self.id])
        row = cursor.fetchone()
        return {'goals_for': row[0], 'goals_against': row[1]}

    def extra_total_goals_for(self):
        # extra returns a queryset
        as_teama = Match.objects.filter(team_a_id=self.id).extra(select={'goals_teama': 'sum(goals_team_a)'})
        goals_as_teama = as_teama[0].goals_teama if as_teama else 0

        as_teamb = Match.objects.filter(team_b_id=self.id).extra(select={'goals_teamb': 'sum(goals_team_b)'})
        goals_as_teamb = as_teamb[0].goals_teamb if as_teamb else 0

        return int(goals_as_teama or 0) + int(goals_as_teamb or 0)

    def extra_total_goals_against(self):
        # extra returns a queryset
        of_teama = Match.objects.filter(team_b_id=self.id).extra(select={'goals_teama': 'sum(goals_team_a)'})
        goals_of_teama = of_teama[0].goals_teama if of_teama else 0

        of_teamb = Match.objects.filter(team_a_id=self.id).extra(select={'goals_teamb': 'sum(goals_team_b)'})
        goals_of_teamb = of_teamb[0].goals_teamb if of_teamb else 0

        return int(goals_of_teama or 0) + int(goals_of_teamb or 0)
