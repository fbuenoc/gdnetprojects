----------------------------
-- LVH.ContentDataTypes
----------------------------
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes',
	@Description = 'WebFramework Data Types',
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
	@Description = 'Text => Simple text-box',
	@CustomValue = '1:01;10:013;11:255;12:32;',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.PasswordTextBox',
	@Description = 'Text => Password text-box',
	@CustomValue = '1:01;10:015;11:255;12:32;',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.TextArea',
	@Description = 'Text => Simple textarea',
	@CustomValue = '1:02;10:015;11:255;12:32;',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.HtmlEditor',
	@Description = 'Text => HTML editor',
	@CustomValue = 'HtmlEditor',
	@ParentName = 'LVH.ContentDataTypes.Text';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Text.Url',
	@Description = 'Text => URL',
	@CustomValue = 'URL',
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
	@Description = 'Number => Integer',
	@CustomValue = 'Integer',
	@ParentName = 'LVH.ContentDataTypes.Number';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Number.UnsignedInteger',
	@Description = 'Number => Unsigned integer',
	@CustomValue = 'UnsignedInteger',
	@ParentName = 'LVH.ContentDataTypes.Number';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Number.Percentage',
	@Description = 'Number => Percentage',
	@CustomValue = 'Percentage',
	@ParentName = 'LVH.ContentDataTypes.Number';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.Number.NormalNumber',
	@Description = 'Number => Normal number',
	@CustomValue = 'NormalNumber',
	@ParentName = 'LVH.ContentDataTypes.Number';
GO

-- DateTime
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime',
	@Description = 'Time',
	@CustomValue = NULL,
	@ParentName = 'LVH.ContentDataTypes';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.Year',
	@Description = 'Time => Year',
	@CustomValue = 'Year',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.Month',
	@Description = 'Time => Month',
	@CustomValue = 'Month',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.Day',
	@Description = 'Time => Day',
	@CustomValue = 'Day',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.DateTime.FullDateTime',
	@Description = 'Time => Day/month/year',
	@CustomValue = 'FullDateTime',
	@ParentName = 'LVH.ContentDataTypes.DateTime';
GO

-- File
exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File',
	@Description = 'File',
	@CustomValue = NULL,
	@ParentName = 'LVH.ContentDataTypes';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.ImageFile',
	@Description = 'File => Image',
	@CustomValue = 'ImageFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.DocumentFile',
	@Description = 'File => Document',
	@CustomValue = 'DocumentFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.ArchiveFile',
	@Description = 'File => Archive',
	@CustomValue = 'ArchiveFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO

exec sp_CreateListValue
	@Name = 'LVH.ContentDataTypes.File.VideoFile',
	@Description = 'File => Video',
	@CustomValue = 'VideoFile',
	@ParentName = 'LVH.ContentDataTypes.File';
GO
