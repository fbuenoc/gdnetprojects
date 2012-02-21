----------------------------
-- LV.ApplicationCategories
----------------------------
exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories',
	@Description = 'Application categories',
	@CustomValue = NULL,
	@ParentName = NULL;
GO

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.Default',
	@Description = 'Default category',
	@CustomValue = '-',
	@ParentName = 'LV.ApplicationCategories';
GO
