----------------------------
-- Content entities translations
----------------------------

-- ContentItem
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.ContentItem.InContentTypeXYZ',
	@CategoryName = 'LV.ApplicationCategories.SysTranslation.ContentItem',
	@Value = 'In content type {0}',
	@IsDeletable = False;


-- Application
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.Application.RootUrl',
	@CategoryName = 'LV.ApplicationCategories.SysTranslation.Application',
	@Value = 'Root Url (without http://)',
	@IsDeletable = False;
