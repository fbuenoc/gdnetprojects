----------------------------
-- LVH.ContentDataTypes
----------------------------
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes',
	@Description = 'WebFramework data types',
	@CustomValue = NULL,
	@ParentName = NULL;
GO

-- Text
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text',
	@Description = 'Text',
	@CustomValue = NULL,
	@ParentName = 'LVH.ContentDataTypes';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.InputTextBox',
	@Description = 'Single row text-box',
	@CustomValue = 'TextBoxSingleRow',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.PasswordInputTextBox',
	@Description = 'Password input text-box',
	@CustomValue = 'PasswordInputTextBox',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.TextArea',
	@Description = 'Textarea input',
	@CustomValue = 'TextArea',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.HtmlEditor',
	@Description = 'Html editor',
	@CustomValue = 'HtmlEditor',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

-- Number
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Number',
	@Description = 'Number',
	@CustomValue = NULL,
	@ParentName = 'LVH.ContentDataTypes';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Number.Integer',
	@Description = 'Integer',
	@CustomValue = 'Integer',
	@ParentName = 'LVH.ContentDataTypes.Number';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Number.UnsignedInteger',
	@Description = 'Unsigned integer',
	@CustomValue = 'UnsignedInteger',
	@ParentName = 'LVH.ContentDataTypes.Number';
GO

-- DateTime
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime',
	@Description = 'Date and time',
	@CustomValue = NULL,
	@ParentName = 'LVH.ContentDataTypes';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.Year',
	@Description = 'Year',
	@CustomValue = 'Year',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.Month',
	@Description = 'Month',
	@CustomValue = 'Month',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.Day',
	@Description = 'Day',
	@CustomValue = 'Day',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.FullDateTime',
	@Description = 'Day, month and year',
	@CustomValue = 'FullDateTime',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

-- File
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File',
	@Description = 'From file',
	@CustomValue = NULL,
	@ParentName = 'LVH.ContentDataTypes';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.ImageFile',
	@Description = 'Image file',
	@CustomValue = 'ImageFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.DocumentFile',
	@Description = 'Document file',
	@CustomValue = 'DocumentFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.ArchiveFile',
	@Description = 'Archive file',
	@CustomValue = 'ArchiveFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.VideoFile',
	@Description = 'Video file',
	@CustomValue = 'VideoFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO