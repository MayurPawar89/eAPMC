USE [eAPMC]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 07/26/2017 18:21:23 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Items_IsActive]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF_Items_IsActive]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Items_CreatedDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF_Items_CreatedDate]
END
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_Table_1_CreatedDate1]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Items] DROP CONSTRAINT [DF_Table_1_CreatedDate1]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Items]') AND type in (N'U'))
DROP TABLE [dbo].[Items]
GO
/****** Object:  Table [dbo].[Items]    Script Date: 07/26/2017 18:21:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Items]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Items](
	[ItemID] [numeric](18, 0) NOT NULL,
	[ItemCode] [tinyint] NOT NULL,
	[ItemDescription] [varchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF_Items_IsActive]  DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Items_CreatedDate]  DEFAULT (getdate()),
	[ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_Table_1_CreatedDate1]  DEFAULT (getdate()),
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Items] ([ItemID], [ItemCode], [ItemDescription], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (CAST(1 AS Numeric(18, 0)), 1, N'Onion', 1, CAST(0x0000A7BC00EBB69C AS DateTime), CAST(0x0000A7BC00EBB69C AS DateTime))
INSERT [dbo].[Items] ([ItemID], [ItemCode], [ItemDescription], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (CAST(2 AS Numeric(18, 0)), 2, N'Tomato', 1, CAST(0x0000A7BC00EBC65D AS DateTime), CAST(0x0000A7BC00EBC65D AS DateTime))
