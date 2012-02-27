----------------------------
-- Content item translations
----------------------------
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.ContentItem.InContentTypeXYZ',
	@CategoryName = 'LV.ApplicationCategories.SysTranslation.ContentItem',
	@Value = 'In content type {0}',
	@IsDeletable = False;
