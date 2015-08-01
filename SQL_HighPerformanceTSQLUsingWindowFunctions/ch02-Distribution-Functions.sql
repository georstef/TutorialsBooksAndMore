-- rk: the RANK of the current row in the window partition
-- nr: count of rows in the window partition
-- np: the number of rows that precede or are peers of the current one in the window partition
-- PERCENT_RANK: percent of students who have a lower test score than the current score => (rk – 1) / (nr – 1)
-- CUME_DIST: percent of students who have a lower or equal test score with the current score => np / nr
SELECT 
  testid, 
  studentid, 
  score,
  RANK() OVER(PARTITION BY testid ORDER BY score) AS rk,
  count(*) OVER(PARTITION BY testid) AS nr,
  count(*) OVER(PARTITION BY testid ORDER BY score) AS np,
  PERCENT_RANK() OVER(PARTITION BY testid ORDER BY score) AS percentrank,
  CUME_DIST() OVER(PARTITION BY testid ORDER BY score) AS cumedist
FROM 
  Stats.Scores;
  
  
-- PERCENTILE_DISC(0.5): the first value in the group whose cumulative distribution (CUME_DIST) is greater than or equal to the input in the window partition
-- PERCENTILE_CONT(0.5): the average of the two middle points when there is an even number of rows in the window partition (it's really fucked up)
DECLARE @pct AS FLOAT = 0.5;
SELECT 
  testid, 
  score,
  RANK() OVER(PARTITION BY testid ORDER BY score) AS rk,
  count(*) OVER(PARTITION BY testid) AS nr,
  count(*) OVER(PARTITION BY testid ORDER BY score) AS np,
  PERCENT_RANK() OVER(PARTITION BY testid ORDER BY score) AS percentrank,
  CUME_DIST() OVER(PARTITION BY testid ORDER BY score) AS cumedist,
  PERCENTILE_DISC(@pct) WITHIN GROUP(ORDER BY score) OVER(PARTITION BY testid) AS percentiledisc,
  PERCENTILE_CONT(@pct) WITHIN GROUP(ORDER BY score) OVER(PARTITION BY testid) AS percentilecont
FROM 
  Stats.Scores;
