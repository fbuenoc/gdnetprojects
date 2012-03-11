-- Application
exec sp_CreateApplication 
	@Name = 'App 01',
	@Description = 'Default Application',
	@CategoryName = 'LV.Default',
	@CultureDefaultCode = 'en-US',
	@RootUrl = '*';
GO

