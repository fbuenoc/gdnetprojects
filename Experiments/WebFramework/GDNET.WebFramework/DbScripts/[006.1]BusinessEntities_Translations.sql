----------------------------
-- Business entities translations
----------------------------

exec SP_CreateListValue
	@Name = 'LV.SysTranslation.Business',
	@Description = 'Business translations',
	@ParentName = 'LV.SysTranslation';
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Business.Description',
	@Value = N'Business',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Business.Detail',
	@Value = N'Business',
	@IsDeletable = False;

-- ///

exec SP_CreateListValue
	@Name = 'LV.SysTranslation.Business.Product',
	@Description = 'Business translations',
	@ParentName = 'LV.SysTranslation.Business';
GO
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Business.Product.Description',
	@Value = N'Sản phẩm',
	@IsDeletable = False;
exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'LV.SysTranslation.Business.Product.Detail',
	@CategoryName = 'LV.SysTranslation.Business',
	@Value = N'Sản phẩm',
	@IsDeletable = False;

-- ///

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.ProductDetail',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = 'Product detail',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.ProductDetail',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = N'Thông tin sản phẩm',
	@IsDeletable = False;
	
-- ///

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.Price',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = 'Price',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.Price',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = N'Giá',
	@IsDeletable = False;

-- ///

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.Discount',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = 'Discount',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.Discount',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = N'Giảm giá',
	@IsDeletable = False;

-- ///

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.RealPrice',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = 'Real price',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.RealPrice',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = N'Giá bán',
	@IsDeletable = False;

-- ///

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'en-US',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.InStock',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = 'In stock',
	@IsDeletable = False;

exec SP_CreateOrUpdateTranslation
	@CultureCode = 'vi-VN',
	@Code = 'ApplicationCategories.SysTranslation.Business.Product.InStock',
	@CategoryName = 'LV.SysTranslation.Business.Product',
	@Value = N'Tình trạng',
	@IsDeletable = False;
