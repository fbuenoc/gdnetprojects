--///////////

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.Application.RootUrl',
	@CategoryName = 'LV.SysTranslation.Application',
	@Value = N'Địa chỉ gốc (không có http://)',
	@IsDeletable = False;
