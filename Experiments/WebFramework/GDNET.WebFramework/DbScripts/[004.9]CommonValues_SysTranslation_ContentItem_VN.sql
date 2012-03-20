exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.ContentItem.Description',
	@Value = N'Bản dịnh Nội dung',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.ContentItem.Detail',
	@Value = N'Bản dịnh Nội dung',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.ContentItem.InContentTypeXYZ',
	@CategoryName = 'LV.SysTranslation.ContentItem',
	@Value = N'Trong kiểu dữ liệu {0}',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'SysTranslation.ContentItem.NameIsRequired',
	@CategoryName = 'LV.SysTranslation.ContentItem',
	@Value = N'Trường Tên cần phải nhập.',
	@IsDeletable = False;
