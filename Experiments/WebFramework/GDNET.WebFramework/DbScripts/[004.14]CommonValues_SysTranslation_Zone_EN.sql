--///////////

exec SP_CreateListValue
	@Name = 'LV.SysTranslation.Zone',
	@Description = 'Zone translations',
	@ParentName = 'LV.SysTranslation';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.Zone.CreateRegion',
	@CategoryName = 'LV.SysTranslation.Zone',
	@Value = 'Create new Region',
	@IsDeletable = False;
