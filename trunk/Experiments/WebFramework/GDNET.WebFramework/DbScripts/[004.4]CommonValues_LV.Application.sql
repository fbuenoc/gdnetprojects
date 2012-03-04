----------------------------
-- LV.ApplicationCategories
----------------------------
exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories',
	@Description = 'Application categories',
	@CustomValue = NULL,
	@ParentName = NULL;
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.Description',
	@Value = 'Các danh mục',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.Detail',
	@Value = 'Các danh mục',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.Default',
	@Description = 'Default category',
	@ParentName = 'LV.ApplicationCategories';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.Default.Description',
	@Value = 'Danh mục mặc định',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.Default.Detail',
	@Value = 'Danh mục mặc định',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.SysTranslation',
	@Description = 'System translations',
	@ParentName = 'LV.ApplicationCategories';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.Description',
	@Value = 'Bản dịnh hệ thống',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.Detail',
	@Value = 'Bản dịnh hệ thống',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.SysTranslation.EntityNames',
	@Description = 'Entitiy names translations',
	@ParentName = 'LV.ApplicationCategories.SysTranslation';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.EntityNames.Description',
	@Value = 'Bản dịnh tên thực thể',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.EntityNames.Detail',
	@Value = 'Bản dịnh tên thực thể',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.SysTranslation.ContentItem',
	@Description = 'Content item translations',
	@ParentName = 'LV.ApplicationCategories.SysTranslation';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.ContentItem.Description',
	@Value = 'Bản dịnh Nội dung',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.ContentItem.Detail',
	@Value = 'Bản dịnh Nội dung',
	@IsDeletable = False;

exec SP_CreateListValue
	@Name = 'LV.ApplicationCategories.SysTranslation.Application',
	@Description = 'Application translations',
	@ParentName = 'LV.ApplicationCategories.SysTranslation';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.Application.Description',
	@Value = 'Bản dịnh Ứng dụng',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.ApplicationCategories.SysTranslation.Application.Detail',
	@Value = 'Bản dịnh Ứng dụng',
	@IsDeletable = False;
