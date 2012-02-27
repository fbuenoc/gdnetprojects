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
	@ParentName = 'LV.ApplicationCategories';
GO

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.SysTranslation',
	@Description = 'System translations',
	@ParentName = 'LV.ApplicationCategories';
GO

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.SysTranslation.EntityNames',
	@Description = 'System translations',
	@ParentName = 'LV.ApplicationCategories.SysTranslation';
GO

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.SysTranslation.ContentItem',
	@Description = 'System translations',
	@ParentName = 'LV.ApplicationCategories.SysTranslation';
GO

