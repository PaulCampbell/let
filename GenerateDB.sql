/****** Object:  ForeignKey [FK_DatedPropertyNotes_RentalProperties]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DatedPropertyNotes_RentalProperties]') AND parent_object_id = OBJECT_ID(N'[dbo].[DatedPropertyNotes]'))
ALTER TABLE [dbo].[DatedPropertyNotes] DROP CONSTRAINT [FK_DatedPropertyNotes_RentalProperties]
GO
/****** Object:  ForeignKey [FK_Offices_Agents]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Offices_Agents]') AND parent_object_id = OBJECT_ID(N'[dbo].[Offices]'))
ALTER TABLE [dbo].[Offices] DROP CONSTRAINT [FK_Offices_Agents]
GO
/****** Object:  ForeignKey [FK_RentalProperties_Offices]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RentalProperties_Offices]') AND parent_object_id = OBJECT_ID(N'[dbo].[RentalProperties]'))
ALTER TABLE [dbo].[RentalProperties] DROP CONSTRAINT [FK_RentalProperties_Offices]
GO
/****** Object:  ForeignKey [FK_RentalProperties_Users]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RentalProperties_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[RentalProperties]'))
ALTER TABLE [dbo].[RentalProperties] DROP CONSTRAINT [FK_RentalProperties_Users]
GO
/****** Object:  ForeignKey [FK_Users_Agents]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Agents]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_Users_Agents]
GO
/****** Object:  Table [dbo].[DatedPropertyNotes]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DatedPropertyNotes]') AND type in (N'U'))
DROP TABLE [dbo].[DatedPropertyNotes]
GO
/****** Object:  Table [dbo].[RentalProperties]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RentalProperties]') AND type in (N'U'))
DROP TABLE [dbo].[RentalProperties]
GO
/****** Object:  Table [dbo].[Offices]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Offices]') AND type in (N'U'))
DROP TABLE [dbo].[Offices]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Tenancies]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tenancies]') AND type in (N'U'))
DROP TABLE [dbo].[Tenancies]
GO
/****** Object:  Table [dbo].[Agents]    Script Date: 08/31/2011 15:26:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Agents]') AND type in (N'U'))
DROP TABLE [dbo].[Agents]
GO
/****** Object:  Table [dbo].[Agents]    Script Date: 08/31/2011 15:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Agents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Agents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PictureUrl] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[Name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_Agents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Tenancies]    Script Date: 08/31/2011 15:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tenancies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tenancies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RentalPropertyId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[PricePerMonth] [decimal](18, 0) NULL,
	[BondAmount] [decimal](18, 0) NULL,
	[AddedBy] [int] NULL,
 CONSTRAINT [PK_Tenancies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08/31/2011 15:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[LastName] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[UserType] [int] NULL,
	[HashedPassword] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[PasswordSalt] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[Email] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[HouseNumber] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[Postcode] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[AddressLine1] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[AddressLine2] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[Town] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[HomeNumber] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[MobileNumber] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[AgentId] [int] NULL,
	[Added] [datetime] NULL,
	[AddedBy] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[Offices]    Script Date: 08/31/2011 15:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Offices]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Offices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AgentId] [int] NULL,
	[Postcode] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[HouseNumber] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[AddressLine1] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[AddressLine2] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[Town] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[Name] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_Offices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[RentalProperties]    Script Date: 08/31/2011 15:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RentalProperties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RentalProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LandlordId] [int] NOT NULL,
	[Postcode] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[HouseNumber] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[AddressLine1] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[AddressLine2] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[Town] [varchar](150) COLLATE Latin1_General_CI_AS NULL,
	[NumberOfBedrooms] [int] NULL,
	[NumberOfBathrooms] [int] NULL,
	[NumberOfReceptionRooms] [int] NULL,
	[PetsAllowed] [bit] NULL,
	[SmokersAllowed] [bit] NULL,
	[OfficeId] [int] NULL,
	[AdvertisedPricePerMonth] [decimal](18, 0) NULL,
	[AdvertisedBondAmount] [decimal](18, 0) NULL,
	[Furnished] [bit] NULL,
	[OnMarket] [bit] NULL,
	[ParkingSpaces] [int] NULL,
	[Summary] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[DetailDescription] [varchar](5000) COLLATE Latin1_General_CI_AS NULL,
	[NotableFeatures] [varchar](5000) COLLATE Latin1_General_CI_AS NULL,
	[GeneralNotes] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
	[Added] [datetime] NULL,
	[AddedBy] [int] NULL,
 CONSTRAINT [PK_RentalProperties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[DatedPropertyNotes]    Script Date: 08/31/2011 15:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DatedPropertyNotes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DatedPropertyNotes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RentalPropertyId] [int] NOT NULL,
	[Added] [datetime] NULL,
	[Note] [varchar](1000) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_DatedPropertyNotes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  ForeignKey [FK_DatedPropertyNotes_RentalProperties]    Script Date: 08/31/2011 15:26:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DatedPropertyNotes_RentalProperties]') AND parent_object_id = OBJECT_ID(N'[dbo].[DatedPropertyNotes]'))
ALTER TABLE [dbo].[DatedPropertyNotes]  WITH CHECK ADD  CONSTRAINT [FK_DatedPropertyNotes_RentalProperties] FOREIGN KEY([RentalPropertyId])
REFERENCES [dbo].[RentalProperties] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DatedPropertyNotes_RentalProperties]') AND parent_object_id = OBJECT_ID(N'[dbo].[DatedPropertyNotes]'))
ALTER TABLE [dbo].[DatedPropertyNotes] CHECK CONSTRAINT [FK_DatedPropertyNotes_RentalProperties]
GO
/****** Object:  ForeignKey [FK_Offices_Agents]    Script Date: 08/31/2011 15:26:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Offices_Agents]') AND parent_object_id = OBJECT_ID(N'[dbo].[Offices]'))
ALTER TABLE [dbo].[Offices]  WITH CHECK ADD  CONSTRAINT [FK_Offices_Agents] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agents] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Offices_Agents]') AND parent_object_id = OBJECT_ID(N'[dbo].[Offices]'))
ALTER TABLE [dbo].[Offices] CHECK CONSTRAINT [FK_Offices_Agents]
GO
/****** Object:  ForeignKey [FK_RentalProperties_Offices]    Script Date: 08/31/2011 15:26:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RentalProperties_Offices]') AND parent_object_id = OBJECT_ID(N'[dbo].[RentalProperties]'))
ALTER TABLE [dbo].[RentalProperties]  WITH CHECK ADD  CONSTRAINT [FK_RentalProperties_Offices] FOREIGN KEY([OfficeId])
REFERENCES [dbo].[Offices] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RentalProperties_Offices]') AND parent_object_id = OBJECT_ID(N'[dbo].[RentalProperties]'))
ALTER TABLE [dbo].[RentalProperties] CHECK CONSTRAINT [FK_RentalProperties_Offices]
GO
/****** Object:  ForeignKey [FK_RentalProperties_Users]    Script Date: 08/31/2011 15:26:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RentalProperties_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[RentalProperties]'))
ALTER TABLE [dbo].[RentalProperties]  WITH CHECK ADD  CONSTRAINT [FK_RentalProperties_Users] FOREIGN KEY([LandlordId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_RentalProperties_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[RentalProperties]'))
ALTER TABLE [dbo].[RentalProperties] CHECK CONSTRAINT [FK_RentalProperties_Users]
GO
/****** Object:  ForeignKey [FK_Users_Agents]    Script Date: 08/31/2011 15:26:16 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Agents]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Agents] FOREIGN KEY([AgentId])
REFERENCES [dbo].[Agents] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Users_Agents]') AND parent_object_id = OBJECT_ID(N'[dbo].[Users]'))
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Agents]
GO
