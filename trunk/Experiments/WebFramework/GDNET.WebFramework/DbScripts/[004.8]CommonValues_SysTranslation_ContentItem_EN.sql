exec SP_CreateListValue
	@Name = 'LV.SysTranslation.ContentItem',
	@Description = 'Content item translations',
	@ParentName = 'LV.SysTranslation';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.ContentItem.InContentTypeXYZ',
	@CategoryName = 'LV.SysTranslation.ContentItem',
	@Value = 'In content type {0}',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.ContentItem.NameIsRequired',
	@CategoryName = 'LV.SysTranslation.ContentItem',
	@Value = 'The name of content item is required.',
	@IsDeletable = False;
