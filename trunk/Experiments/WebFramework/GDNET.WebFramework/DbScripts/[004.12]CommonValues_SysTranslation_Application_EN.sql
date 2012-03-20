--///////////

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.Application.RootUrl',
	@CategoryName = 'LV.SysTranslation.Application',
	@Value = 'Root Url (without http://)',
	@IsDeletable = False;
