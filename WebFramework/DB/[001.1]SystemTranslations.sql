exec SP_AddOrUpdateTranslation 'GUI.LogOnPage.Description', '{0} if you don''t have an account.', 'en';
exec SP_AddOrUpdateTranslation 'GUI.LogOnPage.Description', N'{0} nếu bạn chưa tạo tài khoản.', 'vi';

exec SP_DeleteTranslation 'GUI.LogOnPage.Description1';
exec SP_DeleteTranslation 'GUI.LogOnPage.Description2';
