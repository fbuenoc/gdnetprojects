exec SP_AddOrUpdateTranslation 'GUI.LogOnPage.Description', '{0} if you don''t have an account.', 'en';
exec SP_AddOrUpdateTranslation 'GUI.LogOnPage.Description', N'{0} nếu bạn chưa tạo tài khoản.', 'vi';

exec SP_DeleteTranslation 'GUI.LogOnPage.Description1';
exec SP_DeleteTranslation 'GUI.LogOnPage.Description2';

exec SP_AddOrUpdateTranslation 'GUI.ContentItem.Language', 'Language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.ContentItem.Language', N'Ngôn ngữ', 'vi';

exec SP_AddOrUpdateTranslation 'GUI.User.Language', 'UI language', 'en';
exec SP_AddOrUpdateTranslation 'GUI.User.Language', N'Ngôn ngữ giao diện', 'vi';