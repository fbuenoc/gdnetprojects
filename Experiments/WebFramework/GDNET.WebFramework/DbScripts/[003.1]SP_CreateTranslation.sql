-- Create translation SP
-- @CategoryName: uses to lookup CategoryCode (ListValue)
-- @CultureCode: uses to lookup CultureId (Culture)

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_CreateTranslation' AND type = 'P')
	DROP PROCEDURE sp_CreateTranslation;
GO

create proc sp_CreateTranslation
	@CultureCode varchar(8),
	@Code varchar(512),
	@Value ntext,
	@CategoryName varchar(512) = NULL,
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
	
	declare @CategoryId bigint, @CultureId int;
	set @CategoryId = NULL;
	
	select @CultureId = [Id] from [Culture] where [CultureCode] like @CultureCode;
	if @CategoryName is not NULL
	begin
		select @CategoryId = [Id] from [ListValue] where [Name] like @CategoryName;
	end
	
	declare @TestTranslationId int;
	select @TestTranslationId = [Id] from [Translation] where [Code] like @Code;
	
	if @TestTranslationId > 0 
		begin
			print N'Translation exists: @Code: ' + @Code;
			return @TestTranslationId;
		end
	else
		begin
			-- INSERT INTO TABLE
			INSERT INTO [Translation]
				   ([CategoryId]
				   ,[CultureId]
				   ,[Code]			
				   ,[Value]
				   ,[IsActive]
				   ,[IsEditable]
				   ,[IsDeletable]
				   ,[IsViewable]
				   ,[CreatedBy]
				   ,[CreatedAt]
				   ,[LastModifiedBy]
				   ,[LastModifiedAt]
				   )
			 VALUES
				   (@CategoryId
				   ,@CultureId
				   ,@Code
				   ,@Value
				   ,@IsActive
				   ,@IsEditable
				   ,@IsDeletable
				   ,@IsViewable
				   ,@CreatedBy
				   ,@CreatedAt
				   ,NULL
				   ,NULL
				   );
				   
			print N'Translation insert DONE: @Code: ' + @Code;
			
			return SCOPE_IDENTITY();
		end
end
GO
