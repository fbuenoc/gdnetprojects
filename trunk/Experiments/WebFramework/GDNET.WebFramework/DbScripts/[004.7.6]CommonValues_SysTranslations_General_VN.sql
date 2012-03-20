exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.General.Detail',
	@Value = N'General',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.General.FooterInfo',
	@CategoryName = 'LV.SysTranslation.General',
	@Value = N'Liên hệ: <br /> Điện thoại: 0986 776 724, Email: huanhvhd@gmail.com',
	@IsDeletable = False;
