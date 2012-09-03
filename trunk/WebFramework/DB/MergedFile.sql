-- #####################
-- [000.1]CreateDatabase.sql
-- #####################

USE [master]
GO

/****** Object:  Database [WebFramework]    Script Date: 12/10/2011 23:02:23 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'WebFramework')
DROP DATABASE [WebFramework]
GO

USE [master]
GO

/****** Object:  Database [WebFramework]    Script Date: 12/10/2011 23:02:23 ******/
CREATE DATABASE [WebFramework]
GO

USE [WebFramework]
GO

-- #####################
-- [000.2]CreationScript.sql
-- #####################

USE [WebFramework]
GO
/****** Object:  Table [dbo].[EntityHistory]    Script Date: 07/26/2012 22:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntityHistory](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](512) NOT NULL,
	[LastModifiedAt] [datetime] NULL,
	[LastModifiedBy] [varchar](512) NULL,
 CONSTRAINT [PK_EntityHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntityHistoryComplex]    Script Date: 07/26/2012 22:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntityHistoryComplex](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstLogId] [uniqueidentifier] NULL,
	[LastLogId] [uniqueidentifier] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](512) NOT NULL,
	[LastModifiedAt] [datetime] NULL,
	[LastModifiedBy] [varchar](512) NULL,
 CONSTRAINT [PK_EntityHistoryComplex] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentPart]    Script Date: 07/26/2012 22:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentPart](
	[Id] [uniqueidentifier] NOT NULL,
	[ContentItemId] [uniqueidentifier] NOT NULL,
	[Name] [ntext] NOT NULL,
	[Details] [ntext] NOT NULL,
 CONSTRAINT [PK_ContentPart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntityLog]    Script Date: 07/26/2012 22:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EntityLog](
	[Id] [uniqueidentifier] NOT NULL,
	[EntityHistoryId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](512) NOT NULL,
	[LogMessage] [ntext] NOT NULL,
	[LogContentText] [ntext] NULL,
 CONSTRAINT [PK_EntityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 07/26/2012 22:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [varchar](512) NOT NULL,
	[Password] [varchar](512) NOT NULL,
	[DisplayName] [nvarchar](512) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_User_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentItem]    Script Date: 07/26/2012 22:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [ntext] NOT NULL,
	[Description] [ntext] NULL,
	[Keywords] [ntext] NULL,
 CONSTRAINT [PK_ContentItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_ContentItem_EntityHistoryComplex]    Script Date: 07/26/2012 22:14:24 ******/
ALTER TABLE [dbo].[ContentItem]  WITH CHECK ADD  CONSTRAINT [FK_ContentItem_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[ContentItem] CHECK CONSTRAINT [FK_ContentItem_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_ContentPart_ContentItem]    Script Date: 07/26/2012 22:14:24 ******/
ALTER TABLE [dbo].[ContentPart]  WITH CHECK ADD  CONSTRAINT [FK_ContentPart_ContentItem] FOREIGN KEY([ContentItemId])
REFERENCES [dbo].[ContentItem] ([Id])
GO
ALTER TABLE [dbo].[ContentPart] CHECK CONSTRAINT [FK_ContentPart_ContentItem]
GO
/****** Object:  ForeignKey [FK_ContentPart_EntityHistoryComplex]    Script Date: 07/26/2012 22:14:24 ******/
ALTER TABLE [dbo].[ContentPart]  WITH CHECK ADD  CONSTRAINT [FK_ContentPart_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[ContentPart] CHECK CONSTRAINT [FK_ContentPart_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_EntityHistoryComplex_EntityLog_FirstLog]    Script Date: 07/26/2012 22:14:24 ******/
ALTER TABLE [dbo].[EntityHistoryComplex]  WITH CHECK ADD  CONSTRAINT [FK_EntityHistoryComplex_EntityLog_FirstLog] FOREIGN KEY([FirstLogId])
REFERENCES [dbo].[EntityLog] ([Id])
GO
ALTER TABLE [dbo].[EntityHistoryComplex] CHECK CONSTRAINT [FK_EntityHistoryComplex_EntityLog_FirstLog]
GO
/****** Object:  ForeignKey [FK_EntityHistoryComplex_EntityLog_LastLog]    Script Date: 07/26/2012 22:14:24 ******/
ALTER TABLE [dbo].[EntityHistoryComplex]  WITH CHECK ADD  CONSTRAINT [FK_EntityHistoryComplex_EntityLog_LastLog] FOREIGN KEY([LastLogId])
REFERENCES [dbo].[EntityLog] ([Id])
GO
ALTER TABLE [dbo].[EntityHistoryComplex] CHECK CONSTRAINT [FK_EntityHistoryComplex_EntityLog_LastLog]
GO
/****** Object:  ForeignKey [FK_EntityLog_EntityHistoryComplex]    Script Date: 07/26/2012 22:14:24 ******/
ALTER TABLE [dbo].[EntityLog]  WITH CHECK ADD  CONSTRAINT [FK_EntityLog_EntityHistoryComplex] FOREIGN KEY([EntityHistoryId])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[EntityLog] CHECK CONSTRAINT [FK_EntityLog_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_User_EntityHistoryComplex]    Script Date: 07/26/2012 22:14:24 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_EntityHistoryComplex]
GO

