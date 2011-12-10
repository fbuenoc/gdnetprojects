IF EXISTS (SELECT name FROM sysobjects WHERE name = 'sp_DeleteContentType' AND type = 'P')
	DROP PROCEDURE sp_DeleteContentType;
GO

create proc sp_DeleteContentType
	@ContentTypeId int
as
begin
	begin transaction;
		-- Delete from [Translation]
		declare CursorContentItemNameTranslationId cursor for
		select [NameTranslationId] from [ContentItem] where [ContentTypeId] = @ContentTypeId;
			
		declare ContentItemDescriptionTranslationId cursor for
		select [DescriptionTranslationId] from [ContentItem] where [ContentTypeId] = @ContentTypeId;

		declare ContentTypeNameTranslationId cursor for
		select [NameTranslationId] from [ContentType] where [Id] = @ContentTypeId;
		
		declare ContentItemAttributeValueValueTranslationId cursor for
		select [ValueTranslationId] from [ContentItemAttributeValue]
		where [ContentItemId] in (
			select [Id] from [ContentItem] where [ContentTypeId] = @ContentTypeId
		);
		
		-- Delete ContentItemAttributeValue
		delete from [ContentItemAttributeValue] where [ContentItemId] in (
				select [Id] from [ContentItem] where [ContentTypeId] = @ContentTypeId
		);		
		-- Delete ContentItem
		delete from [ContentItem] where [ContentTypeId] = @ContentTypeId;		
		-- Delete ContentAttribute
		delete from [ContentAttribute] where [ContentTypeId] = @ContentTypeId;
		-- Delete ContentType
		delete from [ContentType] where [Id] = @ContentTypeId;
		
		-- Delete translation
		declare @TranslationId bigint;
		open CursorContentItemNameTranslationId
		fetch next from CursorContentItemNameTranslationId into @TranslationId
		WHILE @@FETCH_STATUS = 0
		BEGIN
			delete from [Translation] where [Id] = @TranslationId;
			fetch next from CursorContentItemNameTranslationId into @TranslationId;
		end
		
		open ContentItemDescriptionTranslationId
		fetch next from ContentItemDescriptionTranslationId into @TranslationId
		WHILE @@FETCH_STATUS = 0
		BEGIN
			delete from [Translation] where [Id] = @TranslationId;
			fetch next from ContentItemDescriptionTranslationId into @TranslationId;
		end
		
		open ContentTypeNameTranslationId
		fetch next from ContentTypeNameTranslationId into @TranslationId
		WHILE @@FETCH_STATUS = 0
		BEGIN
			delete from [Translation] where [Id] = @TranslationId;
			fetch next from ContentTypeNameTranslationId into @TranslationId;
		end
		
		open ContentItemAttributeValueValueTranslationId
		fetch next from ContentItemAttributeValueValueTranslationId into @TranslationId
		WHILE @@FETCH_STATUS = 0
		BEGIN
			delete from [Translation] where [Id] = @TranslationId;
			fetch next from ContentItemAttributeValueValueTranslationId into @TranslationId;
		end
		
		CLOSE CursorContentItemNameTranslationId;
		CLOSE ContentItemDescriptionTranslationId;
		CLOSE ContentTypeNameTranslationId;
		CLOSE ContentItemAttributeValueValueTranslationId;
		
		DEALLOCATE CursorContentItemNameTranslationId;
		DEALLOCATE ContentItemDescriptionTranslationId;
		DEALLOCATE ContentTypeNameTranslationId;
		DEALLOCATE ContentItemAttributeValueValueTranslationId;
		
	commit;
end

GO
