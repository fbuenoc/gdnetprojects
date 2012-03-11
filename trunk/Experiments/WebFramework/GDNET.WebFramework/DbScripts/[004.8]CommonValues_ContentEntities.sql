----------------------------
-- Content entities translations
----------------------------

-- ContentItem
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


-- Application
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.Application.RootUrl',
	@CategoryName = 'LV.SysTranslation.Application',
	@Value = 'Root Url (without http://)',
	@IsDeletable = False;
