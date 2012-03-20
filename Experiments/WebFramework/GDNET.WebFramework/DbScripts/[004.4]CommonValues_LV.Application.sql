/************************************
 ** Created: 		10/02/2012
 ** Description: 	Default List value
 ************************************/

exec SP_CreateListValue
	@Name = 'LV.Default',
	@Description = 'Default category',
	@ParentName = NULL;
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.Default.Description',
	@Value = N'Danh mục mặc định',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.Default.Detail',
	@Value = N'Danh mục mặc định',
	@IsDeletable = False;

-- ///
	
exec SP_CreateListValue
	@Name = 'LV.SysTranslation',
	@Description = 'System translations',
	@ParentName = NULL;
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Description',
	@Value = N'Bản dịnh hệ thống',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Detail',
	@Value = N'Bản dịnh hệ thống',
	@IsDeletable = False;

-- //

exec SP_CreateListValue
	@Name = 'LV.SysTranslation.EntityNames',
	@Description = 'Entitiy names translations',
	@ParentName = 'LV.SysTranslation';
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.EntityNames.Description',
	@Value = N'Bản dịnh tên thực thể',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.EntityNames.Detail',
	@Value = N'Bản dịnh tên thực thể',
	@IsDeletable = False;

-- //


-- // 

exec SP_CreateListValue
	@Name = 'LV.SysTranslation.Application',
	@Description = 'Application translations',
	@ParentName = 'LV.SysTranslation';
GO

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Application.Description',
	@Value = N'Bản dịnh Ứng dụng',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Application.Detail',
	@Value = N'Bản dịnh Ứng dụng',
	@IsDeletable = False;

-- // 
	
exec SP_CreateListValue
	@Name = 'LV.SysTranslation.Business',
	@Description = 'Business translations',
	@ParentName = 'LV.SysTranslation';
GO
