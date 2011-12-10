-- Culture
insert into [Culture] ([CultureCode], [IsActive], [IsDefault]) values ('vi-VN', 1, 0);
insert into [Culture] ([CultureCode], [IsActive], [IsDefault]) values ('en-US', 1, 1);

GO

-- Application
exec sp_CreateApplication 
	@Name = 'App 01',
	@Description = 'Default Application',
	@CategoryName = 'LV.ApplicationCategories.Default',
	@CultureDefaultCode = 'en-US',
	@RootUrl = '*';
GO



