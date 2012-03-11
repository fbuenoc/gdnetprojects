----------------------------
-- Menu translations
----------------------------

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
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.General.Detail',
	@Value = N'General',
	@IsDeletable = False;

-- ///

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.General.FooterInfo',
	@CategoryName = 'LV.SysTranslation.General',
	@Value = 'Contact us <br /> Phone number: 0986 776 724, Email: huanhvhd@gmail.com',
	@IsDeletable = False;
	
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.General.FooterInfo',
	@CategoryName = 'LV.SysTranslation.General',
	@Value = N'Liên hệ: <br /> Điện thoại: 0986 776 724, Email: huanhvhd@gmail.com',
	@IsDeletable = False;
