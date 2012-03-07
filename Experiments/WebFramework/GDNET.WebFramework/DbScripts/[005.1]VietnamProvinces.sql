-- Vietnam Provinces
exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces',
	@Description = 'Vietnam provinces',
	@CustomValue = NULL,
	@ParentName = NULL;
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Description',
	@Value = N'Các tỉnh/thành Việt Nam',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Detail',
	@Value = N'Các tỉnh/thành Việt Nam',
	@IsDeletable = False;


exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi',
	@Description = 'Hanoi',
	@Detail = 'The capital of Vietnam',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.Description',
	@Value = N'Hà Nội',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.Detail',
	@Value = N'Thủ đô Hà Nội',
	@IsDeletable = False;


exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.HoanKiem',
	@Description = 'Hoan Kiem',
	@Detail = 'The central district of Hanoi',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.HoanKiem.Description',
	@Value = N'Quận Hoàn Kiếm',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.HoanKiem.Detail',
	@Value = N'Quận Hoàn Kiếm',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.HaiBaTrung',
	@Description = 'Hai Ba Trung',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.HaiBaTrung.Description',
	@Value = N'Quận Hai Bà Trưng',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.HaiBaTrung.Detail',
	@Value = N'Quận Hai Bà Trưng',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.CauGiay',
	@Description = 'Cau Giay',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.CauGiay.Description',
	@Value = N'Quận Cầu Giấy',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.CauGiay.Detail',
	@Value = N'Quận Cầu Giấy',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.BaDinh',
	@Description = 'Ba Dinh',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.BaDinh.Description',
	@Value = N'Quận Ba Đình',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.BaDinh.Detail',
	@Value = N'Quận Ba Đình',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.DongDa',
	@Description = 'Dong Da',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.DongDa.Description',
	@Value = N'Quận Đống Đa',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.DongDa.Detail',
	@Value = N'Quận Đống Đa',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.LongBien',
	@Description = 'Long Bien',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.LongBien.Description',
	@Value = N'Quận Long Biên',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.VietnamProvinces.Hanoi.LongBien.Detail',
	@Value = N'Quận Long Biên',
	@IsDeletable = False;
