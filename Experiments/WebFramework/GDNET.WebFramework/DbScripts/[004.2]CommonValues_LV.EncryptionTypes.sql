----------------------------
-- LV.EncryptionTypes
----------------------------
exec sp_CreateListValue
	@Name = 'LV.EncryptionTypes',
	@Description = 'WebFramework encryption types',
	@CustomValue = NULL,
	@ParentName = NULL;
GO

exec sp_CreateListValue
	@Name = 'LV.EncryptionTypes.None',
	@Description = 'No encryption',
	@CustomValue = 'None',
	@ParentName = 'LV.EncryptionTypes';
GO

exec sp_CreateListValue
	@Name = 'LV.EncryptionTypes.Base64',
	@Description = 'Base 64',
	@CustomValue = 'Base64',
	@ParentName = 'LV.EncryptionTypes';
GO

exec sp_CreateListValue
	@Name = 'LV.EncryptionTypes.AES',
	@Description = 'AES',
	@CustomValue = 'AES',
	@ParentName = 'LV.EncryptionTypes';
GO
