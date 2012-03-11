----------------------------
-- Menu translations
----------------------------

exec SP_CreateListValue
	@Name = 'LV.SysTranslation.Navigation',
	@Description = 'Navigation',
	@ParentName = 'LV.SysTranslation';
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Navigation.Description',
	@Value = N'Menu',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Navigation.Detail',
	@Value = N'Menu',
	@IsDeletable = False;

-- ///

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.Navigation.Home',
	@CategoryName = 'LV.SysTranslation.Navigation',
	@Value = 'Home',
	@IsDeletable = False;
	
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.Navigation.Home',
	@CategoryName = 'LV.SysTranslation.Navigation',
	@Value = N'Trang chủ',
	@IsDeletable = False;

-- ///
	
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'SysTranslation.Navigation.About',
	@CategoryName = 'LV.SysTranslation.Navigation',
	@Value = 'About',
	@IsDeletable = False;
	
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.Navigation.About',
	@CategoryName = 'LV.SysTranslation.Navigation',
	@Value = N'Về chúng tôi',
	@IsDeletable = False;
	
