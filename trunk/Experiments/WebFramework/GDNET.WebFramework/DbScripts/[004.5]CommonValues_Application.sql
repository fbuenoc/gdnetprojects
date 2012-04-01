-- Application
exec sp_CreateApplication 
	@Name = 'App 01',
	@Description = 'Default Application',
	@CategoryName = 'LV.Default',
	@CultureDefaultCode = 'vi-VN',
	@RootUrl = '*';
GO

