exec SP_CreateListValue
	@Name = 'LV.FileTypes',
	@Description = 'File types',
	@ParentName = NULL;
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.FileTypes.Description',
	@Value = N'Các định dạng file',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.FileTypes.Detail',
	@Value = N'Các định dạng file',
	@IsDeletable = False;

-- Text
exec sp_CreateListValue
	@Name = 'LV.FileTypes.PlainText',
	@Description = 'Plain text',
	@CustomValue = NULL,
	@ParentName = 'LV.FileTypes';
GO

-- Text
exec sp_CreateListValue
	@Name = 'LV.FileTypes.MSWord',
	@Description = 'MS Word',
	@CustomValue = NULL,
	@ParentName = 'LV.FileTypes';
GO

-- Text
exec sp_CreateListValue
	@Name = 'LV.FileTypes.MSExcel',
	@Description = 'MS Excel',
	@CustomValue = NULL,
	@ParentName = 'LV.FileTypes';
GO


-- Text
exec sp_CreateListValue
	@Name = 'LV.FileTypes.Unknown',
	@Description = 'Unknown type',
	@CustomValue = NULL,
	@ParentName = 'LV.FileTypes';
GO
