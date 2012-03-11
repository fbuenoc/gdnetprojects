/************************************
 ** Created: 		10/02/2012
 ** Description: 	Default List value
 ************************************/

exec sp_CreateListValue
	@Name = 'LV.EncryptionTypes',
	@Description = 'Encryption types',
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
