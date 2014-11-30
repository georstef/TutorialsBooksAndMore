-- execution plan suggested the creation of the following indexes
CREATE NONCLUSTERED INDEX idx_posts_clientid ON dbo.posts
  (clientId)
INCLUDE (ID, topicId, postDate)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
GO

CREATE NONCLUSTERED INDEX idx_productRights_productid ON dbo.productRights
  (productId, userLevel)
INCLUDE (clientId)
WITH (
  PAD_INDEX = OFF,
  DROP_EXISTING = OFF,
  STATISTICS_NORECOMPUTE = OFF,
  SORT_IN_TEMPDB = OFF,
  ONLINE = OFF,
  ALLOW_ROW_LOCKS = ON,
  ALLOW_PAGE_LOCKS = ON)
GO