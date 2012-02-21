-- Vietnam Provinces
exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces',
	@Description = 'Vietnam provinces',
	@CustomValue = NULL,
	@ParentName = NULL;
GO

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi',
	@Description = 'Hanoi',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces';
GO

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.HoanKiem',
	@Description = 'Hoan Kiem',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.HaiBaTrung',
	@Description = 'Hai Ba Trung',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.CauGiay',
	@Description = 'Cau Giay',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.BaDinh',
	@Description = 'Ba Dinh',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.DongDa',
	@Description = 'Dong Da',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO

exec SP_CreateListValue
	@Name = 'LV.VietnamProvinces.Hanoi.LongBien',
	@Description = 'Long Bien',
	@CustomValue = NULL,
	@ParentName = 'LV.VietnamProvinces.Hanoi';
GO
