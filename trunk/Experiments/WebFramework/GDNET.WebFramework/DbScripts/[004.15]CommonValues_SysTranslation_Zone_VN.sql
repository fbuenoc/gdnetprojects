--///////////

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Zone.Description',
	@Value = N'Bản dịnh cho Zone',
	@IsDeletable = False;
	
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Zone.Detail',
	@Value = N'Bản dịnh cho Zone',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.Zone.CreateRegion',
	@CategoryName = 'LV.SysTranslation.Zone',
	@Value = N'Tạo Vùng mới',
	@IsDeletable = False;
