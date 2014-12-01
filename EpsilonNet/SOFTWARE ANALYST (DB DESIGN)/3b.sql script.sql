CREATE TABLE dbo.cusCustomer (
  cusCustomerID int IDENTITY(1, 1) NOT NULL,
  cuCustomerName nvarchar(200) COLLATE Greek_CI_AI NOT NULL,
  PRIMARY KEY CLUSTERED (cusCustomerID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.wrhProduct (
  wrhProductID int IDENTITY(1, 1) NOT NULL,
  wrhProductName nvarchar(300) COLLATE Greek_CI_AI NOT NULL,
  PRIMARY KEY CLUSTERED (wrhProductID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckSeverity (
  tckSeverityID int IDENTITY(1, 1) NOT NULL,
  tckSeverityName nvarchar(50) COLLATE Greek_CI_AI NOT NULL,
  PRIMARY KEY CLUSTERED (tckSeverityID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckStatus (
  tckStatusID int IDENTITY(1, 1) NOT NULL,
  tckStatusName nvarchar(50) COLLATE Greek_CI_AI NOT NULL,
  PRIMARY KEY CLUSTERED (tckStatusID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckType (
  tckTypeID int IDENTITY(1, 1) NOT NULL,
  tckTypeName nvarchar(50) COLLATE Greek_CI_AI NOT NULL,
  PRIMARY KEY CLUSTERED (tckTypeID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckUser (
  tckUserID int IDENTITY(1, 1) NOT NULL,
  tckUserName nvarchar(50) COLLATE Greek_CI_AI NOT NULL,
  PRIMARY KEY CLUSTERED (tckUserID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckTicket (
  tckTicketID int IDENTITY(1, 1) NOT NULL,
  tckTicketName nvarchar(50) COLLATE Greek_CI_AI NOT NULL,
  tckTicketDescription nvarchar(max) COLLATE Greek_CI_AI NULL,
  tckTicketDateOpened datetime CONSTRAINT df_tckTicket_tckTicketDateOpened DEFAULT getdate() NOT NULL,
  tckTicketDateClosed datetime NULL,
  tckStatusID int NOT NULL,
  tckUserIDCreator int NOT NULL,
  tckUserIDAssignedTo int NOT NULL,
  tckTypeID int NOT NULL,
  tckSeverityID int NOT NULL,
  cusCustomerID int NULL,
  wrhProductID int NULL,
  PRIMARY KEY CLUSTERED (tckTicketID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
  FOREIGN KEY (cusCustomerID) 
  REFERENCES dbo.cusCustomer (cusCustomerID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (tckSeverityID) 
  REFERENCES dbo.tckSeverity (tckSeverityID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (tckStatusID) 
  REFERENCES dbo.tckStatus (tckStatusID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (tckTypeID) 
  REFERENCES dbo.tckType (tckTypeID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (tckUserIDAssignedTo) 
  REFERENCES dbo.tckUser (tckUserID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (tckUserIDCreator) 
  REFERENCES dbo.tckUser (tckUserID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (wrhProductID) 
  REFERENCES dbo.wrhProduct (wrhProductID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckAttachment (
  tckAttachmentID int IDENTITY(1, 1) NOT NULL,
  tckTicketID int NOT NULL,
  tckAttachmentName nvarchar(100) COLLATE Greek_CI_AI NOT NULL,
  tckAttachmentFile varbinary(1000) NULL,
  PRIMARY KEY CLUSTERED (tckAttachmentID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
  FOREIGN KEY (tckTicketID) 
  REFERENCES dbo.tckTicket (tckTicketID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckAction (
  tckActionID int IDENTITY(1, 1) NOT NULL,
  tckTicketID int NOT NULL,
  tckUserID int NOT NULL,
  tckActionDescription nvarchar(max) COLLATE Greek_CI_AI NOT NULL,
  tckActionDate datetime CONSTRAINT df_tckAction_tckActionDate DEFAULT getdate() NOT NULL,
  PRIMARY KEY CLUSTERED (tckActionID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
  FOREIGN KEY (tckTicketID) 
  REFERENCES dbo.tckTicket (tckTicketID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (tckUserID) 
  REFERENCES dbo.tckUser (tckUserID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
)
ON [PRIMARY]
GO

CREATE TABLE dbo.tckHistory (
  tckHistoryID int IDENTITY(1, 1) NOT NULL,
  tckTicketID int NOT NULL,
  tckUserID int NOT NULL,
  tckHistoryDate datetime CONSTRAINT df_tckHistory_tckHistoryDate DEFAULT getdate() NOT NULL,
  tckHistoryField nvarchar(50) COLLATE Greek_CI_AI NOT NULL,
  tckHistoryPreviousData nvarchar(max) COLLATE Greek_CI_AI NOT NULL,
  PRIMARY KEY CLUSTERED (tckHistoryID)
    WITH (
      PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF,
      ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON),
  FOREIGN KEY (tckTicketID) 
  REFERENCES dbo.tckTicket (tckTicketID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION,
  FOREIGN KEY (tckUserID) 
  REFERENCES dbo.tckUser (tckUserID) 
  ON UPDATE NO ACTION
  ON DELETE NO ACTION
)
ON [PRIMARY]
GO
