/****** Object:  Table [dbo].[Culture]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Culture](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CultureCode] [varchar](8) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Culture] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Culture_CultureCode] UNIQUE NONCLUSTERED 
(
	[CultureCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ListValue]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DescriptionTranslationId] [bigint] NOT NULL,
	[DetailTranslationId] [bigint] NOT NULL,
	[ParentId] [bigint] NULL,
	[ApplicationId] [bigint] NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[Name] [varchar](512) NOT NULL,
	[CustomValue] [nvarchar](512) NULL,
	[Position] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsEditable] [bit] NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[IsViewable] [bit] NOT NULL,
 CONSTRAINT [PK_ListValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ListValue_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ListValue_Name_Parent] UNIQUE NONCLUSTERED 
(
	[Name] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'NULL means root item of the list value' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ListValue', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'It must be Nullable, because it is linked to Application' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ListValue', @level2type=N'COLUMN',@level2name=N'ApplicationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ListValue', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Custom value of ItemValue/ListValue' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ListValue', @level2type=N'COLUMN',@level2name=N'CustomValue'
GO
/****** Object:  Table [dbo].[StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatutLifeCycle](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ActualStatutId] [bigint] NULL,
 CONSTRAINT [PK_StatutLifeCycle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Translation]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Translation](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CategoryId] [bigint] NULL,
	[CultureId] [int] NOT NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[Code] [varchar](512) NOT NULL,
	[Value] [ntext] NULL,
	[IsActive] [bit] NOT NULL,
	[IsEditable] [bit] NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[IsViewable] [bit] NOT NULL,
 CONSTRAINT [PK_Translation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Translation_CultureId_Code] UNIQUE NONCLUSTERED 
(
	[CultureId] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Application]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Application](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NameTranslationId] [bigint] NOT NULL,
	[DescriptionTranslationId] [bigint] NOT NULL,
	[CategoryId] [bigint] NULL,
	[CultureDefaultId] [int] NOT NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[RootUrl] [varchar](768) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsEditable] [bit] NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[IsViewable] [bit] NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Application_RootUrl] UNIQUE NONCLUSTERED 
(
	[RootUrl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentType]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentType](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NameTranslationId] [bigint] NOT NULL,
	[ApplicationId] [bigint] NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[Code] [varchar](512) NOT NULL,
	[TypeName] [varchar](512) NULL,
	[IsActive] [bit] NOT NULL,
	[IsEditable] [bit] NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[IsViewable] [bit] NOT NULL,
 CONSTRAINT [PK_ContentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ContentType_Application_Code] UNIQUE NONCLUSTERED 
(
	[ApplicationId] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Translation code of Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContentType', @level2type=N'COLUMN',@level2name=N'NameTranslationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Type of content item like "GDNET.Employee, GDNET"' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContentType', @level2type=N'COLUMN',@level2name=N'TypeName'
GO
/****** Object:  Table [dbo].[ContentAttribute]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContentAttribute](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ContentTypeId] [bigint] NOT NULL,
	[DataTypeId] [bigint] NOT NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[Code] [varchar](512) NOT NULL,
	[Position] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsEditable] [bit] NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[IsViewable] [bit] NOT NULL,
 CONSTRAINT [PK_ContentTypeAttribute] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ContentAttribute_ContentTypeId_Code] UNIQUE NONCLUSTERED 
(
	[ContentTypeId] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code of attribute, without any space. Like Employee.FullName or Article.Source' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContentAttribute', @level2type=N'COLUMN',@level2name=N'Code'
GO
/****** Object:  Table [dbo].[ContentItem]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentItem](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ContentTypeId] [bigint] NOT NULL,
	[NameTranslationId] [bigint] NOT NULL,
	[DescriptionTranslationId] [bigint] NOT NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[Position] [int] NOT NULL,
	[Views] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsEditable] [bit] NOT NULL,
	[IsDeletable] [bit] NOT NULL,
	[IsViewable] [bit] NOT NULL,
 CONSTRAINT [PK_ContentItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Translation code of Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContentItem', @level2type=N'COLUMN',@level2name=N'NameTranslationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Translation code of Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContentItem', @level2type=N'COLUMN',@level2name=N'DescriptionTranslationId'
GO
/****** Object:  Table [dbo].[ContentItemAttributeValue]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentItemAttributeValue](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ContentAttributeId] [bigint] NOT NULL,
	[ContentItemId] [bigint] NOT NULL,
	[ValueTranslationId] [bigint] NOT NULL,
 CONSTRAINT [PK_ContentItemAttributeValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContentItemRelation]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentItemRelation](
	[ContentItemId] [bigint] NOT NULL,
	[RelationContentItemId] [bigint] NOT NULL,
 CONSTRAINT [PK_ContentItemRelation] PRIMARY KEY CLUSTERED 
(
	[ContentItemId] ASC,
	[RelationContentItemId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatutLog]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatutLog](
	[Id] [uniqueidentifier] NOT NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[StatutId] [bigint] NULL,
	[Description] [ntext] NULL,
	[BackupData] [ntext] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](255) NOT NULL,
 CONSTRAINT [PK_StatutLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Temporary]    Script Date: 02/26/2012 22:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporary](
	[Id] [uniqueidentifier] NOT NULL,
	[EncryptionTypeId] [bigint] NOT NULL,
	[StatutLifeCycleId] [bigint] NOT NULL,
	[Text] [ntext] NOT NULL,
 CONSTRAINT [PK_Temporary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Default [DF_StatutLog_Id]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[StatutLog] ADD  CONSTRAINT [DF_StatutLog_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  Default [DF_Translation_IsViewable]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Translation] ADD  CONSTRAINT [DF_Translation_IsViewable]  DEFAULT ((1)) FOR [IsViewable]
GO
/****** Object:  ForeignKey [FK_Application_Culture]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Culture] FOREIGN KEY([CultureDefaultId])
REFERENCES [dbo].[Culture] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Culture]
GO
/****** Object:  ForeignKey [FK_Application_ListValue]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_ListValue] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ListValue] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_ListValue]
GO
/****** Object:  ForeignKey [FK_Application_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_StatutLifeCycle]
GO
/****** Object:  ForeignKey [FK_Application_Translation_Description]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Translation_Description] FOREIGN KEY([DescriptionTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Translation_Description]
GO
/****** Object:  ForeignKey [FK_Application_Translation_Name]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_Translation_Name] FOREIGN KEY([NameTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_Translation_Name]
GO
/****** Object:  ForeignKey [FK_ContentAttribute_ContentType]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ContentAttribute_ContentType] FOREIGN KEY([ContentTypeId])
REFERENCES [dbo].[ContentType] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContentAttribute] CHECK CONSTRAINT [FK_ContentAttribute_ContentType]
GO
/****** Object:  ForeignKey [FK_ContentAttribute_ListValue]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ContentAttribute_ListValue] FOREIGN KEY([DataTypeId])
REFERENCES [dbo].[ListValue] ([Id])
GO
ALTER TABLE [dbo].[ContentAttribute] CHECK CONSTRAINT [FK_ContentAttribute_ListValue]
GO
/****** Object:  ForeignKey [FK_ContentAttribute_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentAttribute]  WITH CHECK ADD  CONSTRAINT [FK_ContentAttribute_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[ContentAttribute] CHECK CONSTRAINT [FK_ContentAttribute_StatutLifeCycle]
GO
/****** Object:  ForeignKey [FK_ContentItem_ContentType]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItem]  WITH CHECK ADD  CONSTRAINT [FK_ContentItem_ContentType] FOREIGN KEY([ContentTypeId])
REFERENCES [dbo].[ContentType] ([Id])
GO
ALTER TABLE [dbo].[ContentItem] CHECK CONSTRAINT [FK_ContentItem_ContentType]
GO
/****** Object:  ForeignKey [FK_ContentItem_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItem]  WITH CHECK ADD  CONSTRAINT [FK_ContentItem_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[ContentItem] CHECK CONSTRAINT [FK_ContentItem_StatutLifeCycle]
GO
/****** Object:  ForeignKey [FK_ContentItem_Translation_Description]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItem]  WITH CHECK ADD  CONSTRAINT [FK_ContentItem_Translation_Description] FOREIGN KEY([DescriptionTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[ContentItem] CHECK CONSTRAINT [FK_ContentItem_Translation_Description]
GO
/****** Object:  ForeignKey [FK_ContentItem_Translation_Name]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItem]  WITH CHECK ADD  CONSTRAINT [FK_ContentItem_Translation_Name] FOREIGN KEY([NameTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[ContentItem] CHECK CONSTRAINT [FK_ContentItem_Translation_Name]
GO
/****** Object:  ForeignKey [FK_ContentItemAttributeValue_ContentAttribute]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItemAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ContentItemAttributeValue_ContentAttribute] FOREIGN KEY([ContentAttributeId])
REFERENCES [dbo].[ContentAttribute] ([Id])
GO
ALTER TABLE [dbo].[ContentItemAttributeValue] CHECK CONSTRAINT [FK_ContentItemAttributeValue_ContentAttribute]
GO
/****** Object:  ForeignKey [FK_ContentItemAttributeValue_ContentItem]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItemAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ContentItemAttributeValue_ContentItem] FOREIGN KEY([ContentItemId])
REFERENCES [dbo].[ContentItem] ([Id])
GO
ALTER TABLE [dbo].[ContentItemAttributeValue] CHECK CONSTRAINT [FK_ContentItemAttributeValue_ContentItem]
GO
/****** Object:  ForeignKey [FK_ContentItemAttributeValue_Translation_Value]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItemAttributeValue]  WITH CHECK ADD  CONSTRAINT [FK_ContentItemAttributeValue_Translation_Value] FOREIGN KEY([ValueTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[ContentItemAttributeValue] CHECK CONSTRAINT [FK_ContentItemAttributeValue_Translation_Value]
GO
/****** Object:  ForeignKey [FK_ContentItemRelation_ContentItem_ContentItemId]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItemRelation]  WITH CHECK ADD  CONSTRAINT [FK_ContentItemRelation_ContentItem_ContentItemId] FOREIGN KEY([ContentItemId])
REFERENCES [dbo].[ContentItem] ([Id])
GO
ALTER TABLE [dbo].[ContentItemRelation] CHECK CONSTRAINT [FK_ContentItemRelation_ContentItem_ContentItemId]
GO
/****** Object:  ForeignKey [FK_ContentItemRelation_ContentItem_RelationContentItemId]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentItemRelation]  WITH CHECK ADD  CONSTRAINT [FK_ContentItemRelation_ContentItem_RelationContentItemId] FOREIGN KEY([RelationContentItemId])
REFERENCES [dbo].[ContentItem] ([Id])
GO
ALTER TABLE [dbo].[ContentItemRelation] CHECK CONSTRAINT [FK_ContentItemRelation_ContentItem_RelationContentItemId]
GO
/****** Object:  ForeignKey [FK_ContentType_Application]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentType]  WITH CHECK ADD  CONSTRAINT [FK_ContentType_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([Id])
GO
ALTER TABLE [dbo].[ContentType] CHECK CONSTRAINT [FK_ContentType_Application]
GO
/****** Object:  ForeignKey [FK_ContentType_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentType]  WITH CHECK ADD  CONSTRAINT [FK_ContentType_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[ContentType] CHECK CONSTRAINT [FK_ContentType_StatutLifeCycle]
GO
/****** Object:  ForeignKey [FK_ContentType_Translation_Name]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ContentType]  WITH CHECK ADD  CONSTRAINT [FK_ContentType_Translation_Name] FOREIGN KEY([NameTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[ContentType] CHECK CONSTRAINT [FK_ContentType_Translation_Name]
GO
/****** Object:  ForeignKey [FK_ListValue_Application]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ListValue]  WITH CHECK ADD  CONSTRAINT [FK_ListValue_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([Id])
GO
ALTER TABLE [dbo].[ListValue] CHECK CONSTRAINT [FK_ListValue_Application]
GO
/****** Object:  ForeignKey [FK_ListValue_ListValue]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ListValue]  WITH CHECK ADD  CONSTRAINT [FK_ListValue_ListValue] FOREIGN KEY([ParentId])
REFERENCES [dbo].[ListValue] ([Id])
GO
ALTER TABLE [dbo].[ListValue] CHECK CONSTRAINT [FK_ListValue_ListValue]
GO
/****** Object:  ForeignKey [FK_ListValue_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ListValue]  WITH CHECK ADD  CONSTRAINT [FK_ListValue_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[ListValue] CHECK CONSTRAINT [FK_ListValue_StatutLifeCycle]
GO
/****** Object:  ForeignKey [FK_ListValue_Translation_Description]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ListValue]  WITH CHECK ADD  CONSTRAINT [FK_ListValue_Translation_Description] FOREIGN KEY([DescriptionTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[ListValue] CHECK CONSTRAINT [FK_ListValue_Translation_Description]
GO
/****** Object:  ForeignKey [FK_ListValue_Translation_Detail]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[ListValue]  WITH CHECK ADD  CONSTRAINT [FK_ListValue_Translation_Detail] FOREIGN KEY([DetailTranslationId])
REFERENCES [dbo].[Translation] ([Id])
GO
ALTER TABLE [dbo].[ListValue] CHECK CONSTRAINT [FK_ListValue_Translation_Detail]
GO
/****** Object:  ForeignKey [FK_StatutLifeCycle_ListValue]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[StatutLifeCycle]  WITH CHECK ADD  CONSTRAINT [FK_StatutLifeCycle_ListValue] FOREIGN KEY([ActualStatutId])
REFERENCES [dbo].[ListValue] ([Id])
GO
ALTER TABLE [dbo].[StatutLifeCycle] CHECK CONSTRAINT [FK_StatutLifeCycle_ListValue]
GO
/****** Object:  ForeignKey [FK_StatutLog_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[StatutLog]  WITH CHECK ADD  CONSTRAINT [FK_StatutLog_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[StatutLog] CHECK CONSTRAINT [FK_StatutLog_StatutLifeCycle]
GO
/****** Object:  ForeignKey [FK_StatutLot_ListValue]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[StatutLog]  WITH CHECK ADD  CONSTRAINT [FK_StatutLot_ListValue] FOREIGN KEY([StatutId])
REFERENCES [dbo].[ListValue] ([Id])
GO
ALTER TABLE [dbo].[StatutLog] CHECK CONSTRAINT [FK_StatutLot_ListValue]
GO
/****** Object:  ForeignKey [FK_Temporary_ListValue_EncryptionType]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Temporary]  WITH CHECK ADD  CONSTRAINT [FK_Temporary_ListValue_EncryptionType] FOREIGN KEY([EncryptionTypeId])
REFERENCES [dbo].[ListValue] ([Id])
GO
ALTER TABLE [dbo].[Temporary] CHECK CONSTRAINT [FK_Temporary_ListValue_EncryptionType]
GO
/****** Object:  ForeignKey [FK_Temporary_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Temporary]  WITH CHECK ADD  CONSTRAINT [FK_Temporary_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[Temporary] CHECK CONSTRAINT [FK_Temporary_StatutLifeCycle]
GO
/****** Object:  ForeignKey [FK_Translation_Culture]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Translation]  WITH CHECK ADD  CONSTRAINT [FK_Translation_Culture] FOREIGN KEY([CultureId])
REFERENCES [dbo].[Culture] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Translation] CHECK CONSTRAINT [FK_Translation_Culture]
GO
/****** Object:  ForeignKey [FK_Translation_ListValue]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Translation]  WITH CHECK ADD  CONSTRAINT [FK_Translation_ListValue] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ListValue] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Translation] CHECK CONSTRAINT [FK_Translation_ListValue]
GO
/****** Object:  ForeignKey [FK_Translation_StatutLifeCycle]    Script Date: 02/26/2012 22:48:47 ******/
ALTER TABLE [dbo].[Translation]  WITH CHECK ADD  CONSTRAINT [FK_Translation_StatutLifeCycle] FOREIGN KEY([StatutLifeCycleId])
REFERENCES [dbo].[StatutLifeCycle] ([Id])
GO
ALTER TABLE [dbo].[Translation] CHECK CONSTRAINT [FK_Translation_StatutLifeCycle]
GO
