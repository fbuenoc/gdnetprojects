-- Culture
insert into [Culture] ([CultureCode], [IsActive], [IsDefault]) values ('vi-VN', 1, 1);
insert into [Culture] ([CultureCode], [IsActive], [IsDefault]) values ('en-US', 1, 0);


-- LV.WebFrameworkListValue
exec sp_CreateListValue
	@Name = 'LV.WFLV',
	@Description = 'WebFramework list value',
	@CustomValue = NULL,
	@ParentName = NULL;
GO
