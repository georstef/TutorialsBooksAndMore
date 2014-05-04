import datetime
from django.utils import timezone
from django.test import TestCase
from django.core.urlresolvers import reverse
from polls.models import Poll

# Create your tests here.

class PollMethodTests(TestCase):
    # functions must begin with "test"
    def test_was_published_recently_with_future_poll(self):
        """
        was_published_recently() should return false for polls whose
        pub_date is in the future
        """
        future_poll = Poll(pub_date=timezone.now() + datetime.timedelta(days=30))
        self.assertEqual(future_poll.was_published_recently(), False)

    def test_was_published_recently_with_old_poll(self):
        """
        was_published_recently() should return false for polls whose
        pub_date is older than 1 day
        """
        old_poll = Poll(pub_date=timezone.now() - datetime.timedelta(days=2))
        self.assertEqual(old_poll.was_published_recently(), False)

    def test_was_published_recently_with_recent_poll(self):
        """
        was_published_recently() should return false for polls whose
        pub_date is within the last 24 hours
        """
        recent_poll = Poll(pub_date=timezone.now() - datetime.timedelta(hours=5))
        self.assertEqual(recent_poll.was_published_recently(), True)

# create a poll for testing
def create_poll(question, days):
    """
    creates a poll
    (the pub_date is in the past or in the future
    depends if "days" is a negative or positive number)
    """
    return Poll.objects.create(
        question=question,
        pub_date=timezone.now()+datetime.timedelta(days=days)
        )

# ************
# VIEW TESTING
# ************
class PollViewTests(TestCase):
    def test_index_view_with_no_polls(self):
        """
        test for when there are no polls to show
        """
        response = self.client.get('/polls/')
        self.assertEqual(response.status_code, 200)
        self.assertContains(response, 'No polls are available')
        self.assertQuerysetEqual(response.context['latest_poll_list'], [])

    def test_index_view_with_a_past_poll(self):
        """
        creates a poll with in a past date
        checks if it is returned
        """
        create_poll('past poll', -30)
        response = self.client.get('/polls/')
        self.assertQuerysetEqual(response.context['latest_poll_list'], ['<Poll: past poll>'])
    
    def test_index_view_with_a_future_poll(self):
        """
        creates a poll with in a future date
        checks if it is returned
        """
        create_poll('future poll', +30)
        response = self.client.get('/polls/')
        self.assertContains(response, "No polls are available.", status_code = 200)
        self.assertQuerysetEqual(response.context['latest_poll_list'], [])

    def test_index_view_with_a_future_and_past_poll(self):
        """
        creates a poll with in a past date
        checks if it is returned
        """
        create_poll('future poll', +30)
        create_poll('past poll', -30)
        response = self.client.get('/polls/')
        self.assertQuerysetEqual(response.context['latest_poll_list'], ['<Poll: past poll>'])

    def test_index_view_with_two_past_polls(self):
        """
        creates a poll with in a past date
        checks if it is returned
        """
        create_poll('past poll #1', -1)
        create_poll('past poll #2', -30)
        response = self.client.get('/polls/')
        self.assertEqual(len(response.context['latest_poll_list']), 2)
        self.assertQuerysetEqual(response.context['latest_poll_list'],
                                 ['<Poll: past poll #1>', '<Poll: past poll #2>'])

# ********************
# GENERIC VIEW TESTING
# ********************
class PollIndexDetailTests(TestCase):
    def test_detail_view_with_a_future_poll(self):
        """
        creates a poll with in a future date 
        checks if it returns 404
        """
        future_poll = create_poll('future poll', +30)
        response = self.client.get(reverse('polls:detail_url_alias', args=(future_poll.id,)))
        self.assertEqual(response.status_code, 404)
       
    def test_detail_view_with_a_past_poll(self):
        """
        creates a poll with in a future date 
        checks if it returns 404
        """
        past_poll = create_poll('future poll', -30)
        response = self.client.get(reverse('polls:detail_url_alias', args=(past_poll.id,)))
        self.assertEqual(response.status_code, 200)
