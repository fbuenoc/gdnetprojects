exec SP_CreateListValue
	@Name = 'LV.SysTranslation.General',
	@Description = 'General',
	@ParentName = 'LV.SysTranslation';
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'LV.SysTranslation.General.Description',
	@Value = N'General',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.General.FooterInfo',
	@CategoryName = 'LV.SysTranslation.General',
	@Value = 'Contact us <br /> Phone number: 0986 776 724, Email: huanhvhd@gmail.com',
	@IsDeletable = False;
