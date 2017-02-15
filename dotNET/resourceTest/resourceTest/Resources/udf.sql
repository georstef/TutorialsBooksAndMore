SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[XXXXXXXXXX]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[XXXXXXXXXX]
GO

-- INSERT UDF HERE
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



