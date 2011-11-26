-- CreateListValue
-- @ParentName: Use to look ParentId

IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_CreateListValue' AND type = 'P')
	DROP PROCEDURE sp_CreateListValue;
GO

create proc sp_CreateListValue
	@Name varchar(512),
	@Description ntext,
	@CustomValue nvarchar(256) = NULL,
	@ParentName varchar(512) = NULL,
	@Position int = 0,
	@IsActive bit = 1,
	@IsEditable bit = 1,
	@IsDeletable bit = 1,
	@IsViewable bit = 1,
	@CreatedBy varchar(255) = 'webframework@gmail.com',
	@CreatedAt datetime = NULL,
	@ApplicationId int = NULL
as
begin
	-- Test the value is exists
	declare @TestListValueId bigint;
	select @TestListValueId = [Id] from [ListValue] where [Name] like @Name;

	if @TestListValueId > 0
		begin
			print 'The list: @Name: ' + @Name + ' is already exists.'
		end		
	else
		begin			
			-- Correct @CreatedAt
			if @CreatedAt is NULL
			begin
				select @CreatedAt = GETDATE();
			end

			-- Calculate @ParentId
			declare @ParentId bigint;
			set @ParentId = NULL;
			if @ParentName is not NULL
				begin
					select @ParentId = [Id] from [ListValue] where [Name] like @ParentName;
				end

			-- Calculate @TranslationDescriptionCode
			declare @TranslationDescriptionCode varchar(512);
			if @ParentName is NULL
				begin
					select @TranslationDescriptionCode = 'WF.ListValue.' + @Name + '.Description';
				end
			else
				begin
					select @TranslationDescriptionCode = @Name + '.Description';
				end
			
			begin transaction
				declare @DescriptionTranslationId bigint;
				exec @DescriptionTranslationId = sp_CreateTranslation
						@CultureCode = 'vi-VN',
						@Code = @TranslationDescriptionCode,
						@Value = @Description;	
				
				INSERT INTO [ListValue]
					   ([DescriptionTranslationId]
					   ,[ParentId]
					   ,[ApplicationId]
					   ,[Name]
					   ,[CustomValue]
					   ,[Position]
					   ,[IsActive]
					   ,[IsEditable]
					   ,[IsDeletable]
					   ,[IsViewable]
					   ,[CreatedBy]
					   ,[CreatedAt]
					   ,[LastModifiedBy]
					   ,[LastModifiedAt])
				 VALUES
					   (@DescriptionTranslationId
					   ,@ParentId
					   ,@ApplicationId
					   ,@Name
					   ,@CustomValue
					   ,@Position
					   ,@IsActive
					   ,@IsEditable
					   ,@IsDeletable
					   ,@IsViewable
					   ,@CreatedBy
					   ,@CreatedAt
					   ,NULL
					   ,NULL);
				
				print N'List insert DONE: @Name: ' + @Name;
						
			commit;
		end
end;