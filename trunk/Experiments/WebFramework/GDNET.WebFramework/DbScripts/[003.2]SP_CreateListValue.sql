-- CreateListValue
-- @ParentName: Use to look ParentId

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'SP_CreateListValue' AND type = 'P')
	DROP PROCEDURE SP_CreateListValue;
GO

create proc SP_CreateListValue
	@Name varchar(512),
	@Description ntext,
	@Detail ntext = NULL,
	@CustomValue nvarchar(256) = NULL,
	@ParentName varchar(512) = NULL,
	@Position int = 0,
	@IsActive bit = 1,
	@IsEditable bit = 1,
	@IsDeletable bit = 1,
	@IsViewable bit = 1,
	@CreatedBy varchar(255) = 'webframework@gmail.com',
	@ApplicationId int = NULL
as
begin
	declare @CreatedAt datetime;
	select @CreatedAt = GETDATE();
	
	if @Detail IS NULL
	begin
		set @Detail = @Description;
	end
	
	-- Test the value is exists
	declare @TestListValueId bigint, @StatutLifeCycleId int;
	select @TestListValueId = [Id], @StatutLifeCycleId = [StatutLifeCycleId] from [ListValue] where [Name] like @Name;

	if @TestListValueId > 0
		begin
			print N'List exists DONE: @Name: ' + @Name;
		end		
	else
		begin			
			-- Calculate @ParentId
			declare @ParentId bigint;
			set @ParentId = NULL;
			if @ParentName is not NULL
				begin
					select @ParentId = [Id] from [ListValue] where [Name] like @ParentName;
				end

			-- Calculate @TranslationDescriptionCode
			declare @TranslationDescriptionCode varchar(512);
			declare @TranslationDetailCode varchar(512);
			if @ParentName is NULL
				begin
					select @TranslationDescriptionCode = 'WF.ListValue.' + @Name + '.Description';
					select @TranslationDetailCode = 'WF.ListValue.' + @Name + '.Detail';
				end
			else
				begin
					select @TranslationDescriptionCode = @Name + '.Description';
					select @TranslationDetailCode = @Name + '.Detail';
				end
			
			begin transaction
				
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
				
				declare @DescriptionTranslationId bigint;
				declare @DetailTranslationId bigint;
				exec @DescriptionTranslationId = SP_CreateOrUpdateTranslation
						@CultureCode = 'en-US',
						@Code = @TranslationDescriptionCode,
						@Value = @Description,
						@IsDeletable = False;
				exec @DetailTranslationId = SP_CreateOrUpdateTranslation
						@CultureCode = 'en-US',
						@Code = @TranslationDetailCode,
						@Value = @Detail,
						@IsDeletable = False;
				
				INSERT INTO [ListValue]
					   ([DescriptionTranslationId]
					   ,[DetailTranslationId]
					   ,[ParentId]
					   ,[ApplicationId]
					   ,[StatutLifeCycleId]
					   ,[Name]
					   ,[CustomValue]
					   ,[Position]
					   ,[IsActive]
					   ,[IsEditable]
					   ,[IsDeletable]
					   ,[IsViewable]
					   )
				 VALUES
					   (@DescriptionTranslationId
					   ,@DetailTranslationId
					   ,@ParentId
					   ,@ApplicationId
					   ,@StatutLifeCycleId
					   ,@Name
					   ,@CustomValue
					   ,@Position
					   ,@IsActive
					   ,@IsEditable
					   ,@IsDeletable
					   ,@IsViewable
					   );
				
				print N'List insert DONE: @Name: ' + @Name;
			commit;
		end
end;
GO

---------
-- TESTS
---------
--EXEC SP_CreateListValue
--	@Name = 'LV.ApplicationCategories123',
--	@Description = 'Application categories123',
--	@CustomValue = NULL,
--	@ParentName = NULL;
--GO
