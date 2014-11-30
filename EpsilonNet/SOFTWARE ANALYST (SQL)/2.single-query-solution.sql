-- SQL SERVER 2012
select
  Trealname.realName,
  projtrack_issues.issueseverityid,
  COUNT(posts.Id) as NumOfIssues,
  CAST(
    AVG(
      CAST(
        DATEDIFF(dd, p_question.postDate, posts.postDate) - Tdays.weekendDays 
      as decimal(5,1))
    ) 
   as decimal(5,1)) as daysToAnswer
from 
  posts
left join
  clients on clients.ID = posts.clientId
left join
  topics on topics.ID = posts.topicId
left join
  projtrack_issues on projtrack_issues.issueId = topics.issueId
outer apply
  -- take the realname if it exists else take the nickname 
  (
   select   
     CASE WHEN projtrack_realnames.realname is not null THEN
       projtrack_realnames.realname
     ELSE
       '[nickname] ' + projtrack_users.firstname + ' ' + projtrack_users.surname
      END as realName
    from projtrack_users 
    left join projtrack_realnames on projtrack_realnames.userid = projtrack_users.userid
    where projtrack_users.username = clients.username
   ) as Trealname
outer apply
  -- only take previous post
  (select top 1 * from posts as p where p.topicId = topics.Id and p.ID < posts.ID order by p.postDate desc) as p_question
outer apply
  -- count weekend days
  (select count(*) as weekendDays from dates where dates.date between p_question.postDate and posts.postDate) as Tdays
where
  -- only take posts of moderators
  clients.ID in (select productRights.clientId from productRights where productRights.productId = 21 and productRights.userLevel >= 6)
group by
  Trealname.realname,
  projtrack_issues.issueseverityid 
order by
  Trealname.realname,
  projtrack_issues.issueseverityid 
