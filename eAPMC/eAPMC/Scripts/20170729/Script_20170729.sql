
GO
/****** Object:  Table [dbo].[EnumInformation]    Script Date: 29-07-2017 10:42:54 PM ******/
DROP TABLE [dbo].[EnumInformation]
GO
/****** Object:  StoredProcedure [dbo].[gsp_GetChallanOnLoadInfo]    Script Date: 29-07-2017 10:42:54 PM ******/
DROP PROCEDURE [dbo].[gsp_GetChallanOnLoadInfo]
GO
/****** Object:  StoredProcedure [dbo].[gsp_GetChallanOnLoadInfo]    Script Date: 29-07-2017 10:42:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[gsp_GetChallanOnLoadInfo] 
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	declare @d datetime
    set @d = getdate()
	select replace(convert(varchar(8), @d, 112)+convert(varchar(8), @d, 114), ':','') as ChallanNo, CONVERT(VARCHAR(50), GETDATE(),121) as ChallanDateTime
	--convert(varchar(10), GETDATE(), 108) as ChallanTime,
	--CONVERT(VARCHAR(10), GETDATE(), 105) as ChallanDate
	Select PersonId as PersonID, Code as PersonCode,FirstName+' '+LastName as PersonName from Person where PersonTypeCode=0--Farmer
	select PersonId as PersonID, Code as PersonCode,FirstName+' '+LastName as PersonName from Person where PersonTypeCode=1--Driver
	select ItemCode as Code,ItemDescription as [Description] from Items where IsActive=1
	select Enum as Code, EnumValue as [Description] from EnumInformation where enumType='Vehicle'
END

GO
/****** Object:  Table [dbo].[EnumInformation]    Script Date: 29-07-2017 10:42:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EnumInformation](
	[EnumID] [numeric](18, 0) NOT NULL,
	[Enum] [int] NOT NULL,
	[EnumValue] [varchar](100) NOT NULL,
	[EnumType] [varchar](255) NOT NULL,
 CONSTRAINT [PK_EnumInformation] PRIMARY KEY CLUSTERED 
(
	[EnumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(1 AS Numeric(18, 0)), 0, N'MobileNo', N'Contact')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(2 AS Numeric(18, 0)), 1, N'FaxNo', N'Contact')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(3 AS Numeric(18, 0)), 2, N'EmailID', N'Contact')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(4 AS Numeric(18, 0)), 0, N'Individual', N'Entity')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(5 AS Numeric(18, 0)), 1, N'Organazation', N'Entity')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(6 AS Numeric(18, 0)), 0, N'Farmer', N'Person')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(7 AS Numeric(18, 0)), 1, N'Driver', N'Person')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(8 AS Numeric(18, 0)), 2, N'Sellar', N'Person')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(9 AS Numeric(18, 0)), 0, N'AadhaarCard', N'Card')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(10 AS Numeric(18, 0)), 1, N'PanCard', N'Card')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(11 AS Numeric(18, 0)), 2, N'DrivingLicenceID', N'Card')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(12 AS Numeric(18, 0)), 3, N'OtherIDCard', N'Card')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(13 AS Numeric(18, 0)), 0, N'Pickup', N'Vehicle')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(14 AS Numeric(18, 0)), 1, N'Tractor', N'Vehicle')
INSERT [dbo].[EnumInformation] ([EnumID], [Enum], [EnumValue], [EnumType]) VALUES (CAST(15 AS Numeric(18, 0)), 2, N'Jeep', N'Vehicle')
