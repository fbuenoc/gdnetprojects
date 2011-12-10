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
	@Name = 'LVH.ContentDataTypes.Text.SimpleTextBox',
	@Description = 'An input for text with one row only',
	@CustomValue = '1:01;10:013;11:255;12:32;',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.PasswordTextBox',
	@Description = 'Password input text-box',
	@CustomValue = '1:01;10:015;11:255;12:32;',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.TextArea',
	@Description = 'Simple text-area',
	@CustomValue = '1:02;10:015;11:255;12:32;',
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
