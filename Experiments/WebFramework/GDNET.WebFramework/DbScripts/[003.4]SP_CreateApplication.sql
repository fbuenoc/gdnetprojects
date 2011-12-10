-- Create Application SP
-- @CategoryName: uses to lookup CategoryCode (ListValue)
-- @CultureCode: uses to lookup CultureId (Culture)

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_CreateApplication' AND type = 'P')
	DROP PROCEDURE sp_CreateApplication;
GO

create proc sp_CreateApplication
	@Name nvarchar(256),
	@Description varchar(512),
	@CategoryName varchar(512),
	@CultureDefaultCode varchar(8),
	@RootUrl varchar(768),
	@IsActive bit = 1,
	@IsEditable bit = 1,
	@IsDeletable bit = 1,
	@IsViewable bit = 1,
	@CreatedBy varchar(255) = 'webframework@gmail.com',
	@CreatedAt datetime = NULL
as
begin
	-- Correct @CreatedAt
	if @CreatedAt is NULL
	begin
		select @CreatedAt = GETDATE();
	end
	
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
		
		select @DescriptionTranslationCode = NEWID();
		select @NameTranslationCode = NEWID();
		
		exec @NameTranslationId = sp_CreateTranslation
							@CultureCode = 'en-US',
							@Code = @NameTranslationCode,
							@Value = @Name;
							
		exec @DescriptionTranslationId = sp_CreateTranslation
							@CultureCode = 'en-US',
							@Code = @DescriptionTranslationCode,
							@Value = @Description;

		INSERT INTO [dbo].[Application]
			   ([NameTranslationId]
			   ,[DescriptionTranslationId]
			   ,[CategoryId]
			   ,[CultureDefaultId]
			   ,[RootUrl]
			   ,[IsActive]
			   ,[IsEditable]
			   ,[IsDeletable]
			   ,[IsViewable]
			   ,[CreatedBy]
			   ,[CreatedAt])
		 VALUES
			   (@NameTranslationId
			   ,@DescriptionTranslationId
			   ,@CategoryId
			   ,@CultureDefaultId
			   ,@RootUrl
			   ,@IsActive
			   ,@IsEditable
			   ,@IsDeletable
			   ,@IsViewable
			   ,@CreatedBy
			   ,@CreatedAt)
		
		declare @applicationId varchar(10);
		select @applicationId = convert(varchar(10), SCOPE_IDENTITY());
		
		update [dbo].[Translation] set [Code] = 'WF.Application.' + @applicationId + '.Name' where [Code] like @NameTranslationCode;
		update [dbo].[Translation] set [Code] = 'WF.Application.' + @applicationId + '.Description' where [Code] like @DescriptionTranslationCode;
	
	commit;
		
end

GO
