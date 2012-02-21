-- Create translation SP
-- @CategoryName: uses to lookup CategoryCode (ListValue)
-- @CultureCode: uses to lookup CultureId (Culture)

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'SP_CreateOrUpdateTranslation' AND type = 'P')
	DROP PROCEDURE SP_CreateOrUpdateTranslation;
GO

create proc SP_CreateOrUpdateTranslation
	@CultureCode varchar(8),
	@Code varchar(512),
	@Value ntext,
	@CategoryName varchar(512) = NULL,
	@IsActive bit = 1,
	@IsEditable bit = 1,
	@IsDeletable bit = 1,
	@IsViewable bit = 1,
	@CreatedBy varchar(255) = 'webframework@gmail.com'
as
begin
	declare @CreatedAt datetime;
	select @CreatedAt = GETDATE();
	
	declare @CategoryId bigint, @CultureId int;
	set @CategoryId = NULL;
	
	select @CultureId = [Id] from [Culture] where [CultureCode] like @CultureCode;
	if @CategoryName is not NULL
	begin
		select @CategoryId = [Id] from [ListValue] where [Name] like @CategoryName;
	end
	
	declare @TestTranslationId int, @StatutLifeCycleId int;
	select @TestTranslationId = [Id], @StatutLifeCycleId = [StatutLifeCycleId] from [Translation] where [Code] like @Code;
	
	if @TestTranslationId > 0 
		begin
			UPDATE [Translation]
			SET [CategoryId] = @CategoryId
				  ,[CultureId] = @CultureId
				  ,[Value] = @Value
				  ,[IsActive] = @IsActive
				  ,[IsEditable] = @IsEditable
				  ,[IsDeletable] = @IsDeletable
				  ,[IsViewable] = @IsViewable
			WHERE [Id] = @TestTranslationId;
			
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
			
			 
			print N'Translation update DONE: @Code: ' + @Code;
			return @TestTranslationId;
		end
	else
		begin
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
			
			-- INSERT INTO TABLE
			INSERT INTO [Translation]
				   ([CategoryId]
				   ,[CultureId]
				   ,[StatutLifeCycleId]
				   ,[Code]			
				   ,[Value]
				   ,[IsActive]
				   ,[IsEditable]
				   ,[IsDeletable]
				   ,[IsViewable]
				   )
			 VALUES
				   (@CategoryId
				   ,@CultureId
				   ,@StatutLifeCycleId
				   ,@Code
				   ,@Value
				   ,@IsActive
				   ,@IsEditable
				   ,@IsDeletable
				   ,@IsViewable
				   );
				   
			print N'Translation insert DONE: @Code: ' + @Code;
			
			return SCOPE_IDENTITY();
		end
end
GO

---------
-- TESTS
---------
--EXEC SP_CreateOrUpdateTranslation
--	@CultureCode = 'en-US',
--	@Code = 'C1',
--	@Value = 'Content 1';
--GO

