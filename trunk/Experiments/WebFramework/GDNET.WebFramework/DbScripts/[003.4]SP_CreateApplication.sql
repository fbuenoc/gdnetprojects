-- Create Application SP
-- @CategoryName: uses to lookup CategoryCode (ListValue)
-- @CultureCode: uses to lookup CultureId (Culture)

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'SP_CreateApplication' AND type = 'P')
	DROP PROCEDURE SP_CreateApplication;
GO

create proc SP_CreateApplication
	@Name nvarchar(256),
	@Description varchar(512),
	@CategoryName varchar(512),
	@CultureDefaultCode varchar(8),
	@RootUrl varchar(768),
	@IsActive bit = 1,
	@IsEditable bit = 1,
	@IsDeletable bit = 1,
	@IsViewable bit = 1,
	@CreatedBy varchar(255) = 'webframework@gmail.com'
as
begin
	declare @CreatedAt datetime;
	select @CreatedAt = GETDATE();
	
	declare @CategoryId bigint, @CultureDefaultId int;
	set @CategoryId = NULL;
	
	select @CultureDefaultId = [Id] from [Culture] where [CultureCode] like @CultureDefaultCode;
	if @CategoryName is not NULL
	begin
		select @CategoryId = [Id] from [ListValue] where [Name] like @CategoryName;
	end

	begin transaction
		
		-- Calculate @TranslationDescriptionCode
		declare @DescriptionTranslationId bigint;
		declare @NameTranslationId bigint;
		declare @DescriptionTranslationCode varchar(512);
		declare @NameTranslationCode varchar(512);
		declare	@StatutLifeCycleId bigint;
		
		select @DescriptionTranslationCode = NEWID();
		select @NameTranslationCode = NEWID();
		
		exec @NameTranslationId = SP_CreateOrUpdateTranslation
							@CultureCode = 'en-US',
							@Code = @NameTranslationCode,
							@Value = @Name,
							@IsDeletable = False;
							
		exec @DescriptionTranslationId = SP_CreateOrUpdateTranslation
							@CultureCode = 'en-US',
							@Code = @DescriptionTranslationCode,
							@Value = @Description,
							@IsDeletable = False;


		INSERT INTO [StatutLifeCycle]
			   ([ActualStatutId])
		VALUES
			   (NULL);
			   
		SELECT @StatutLifeCycleId = SCOPE_IDENTITY();
		
		INSERT INTO [StatutLog]
			   ([Id]
			   ,[StatutLifeCycleId]
			   ,[StatutId]
			   ,[Description]
			   ,[BackupData]
			   ,[CreatedAt]
			   ,[CreatedBy])
		 VALUES
			   (newid()
			   ,@StatutLifeCycleId
			   ,NULL
			   ,'SQL Update'
			   ,NULL
			   ,@CreatedAt
			   ,@CreatedBy);


		INSERT INTO [dbo].[Application]
			   ([NameTranslationId]
			   ,[DescriptionTranslationId]
			   ,[CategoryId]
			   ,[CultureDefaultId]
			   ,[StatutLifeCycleId]
			   ,[RootUrl]
			   ,[IsActive]
			   ,[IsEditable]
			   ,[IsDeletable]
			   ,[IsViewable])
		 VALUES
			   (@NameTranslationId
			   ,@DescriptionTranslationId
			   ,@CategoryId
			   ,@CultureDefaultId
			   ,@StatutLifeCycleId
			   ,@RootUrl
			   ,@IsActive
			   ,@IsEditable
			   ,@IsDeletable
			   ,@IsViewable)
		
		declare @applicationId varchar(10);
		select @applicationId = convert(varchar(10), SCOPE_IDENTITY());
		
		update [dbo].[Translation] set [Code] = 'WF.Application.' + @applicationId + '.Name' where [Code] like @NameTranslationCode;
		update [dbo].[Translation] set [Code] = 'WF.Application.' + @applicationId + '.Description' where [Code] like @DescriptionTranslationCode;
	
	commit;
		
end

GO

---------
-- TESTS
---------
--exec sp_CreateApplication 
--	@Name = 'App 02',
--	@Description = 'Default Application',
--	@CategoryName = NULL,
--	@CultureDefaultCode = 'en-US',
--	@RootUrl = '*';
--GO


