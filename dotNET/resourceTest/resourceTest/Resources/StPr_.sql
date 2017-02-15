if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[StPr_InsertEntoliApokin]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[StPr_InsertEntoliApokin]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS OFF
GO

-- INSERT STORED PROCEDURE HERE

GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
