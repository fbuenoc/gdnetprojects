----------------------------
-- LV.StatutLogs
----------------------------
exec sp_CreateListValue
	@Name = 'LV.StatutLogs',
	@Description = 'Entity statut logs',
	@CustomValue = NULL,
	@ParentName = NULL;
GO

-- Text
exec sp_CreateListValue
	@Name = 'LV.StatutLogs.Created',
	@Description = 'Created',
	@CustomValue = NULL,
	@ParentName = 'LV.StatutLogs';
GO

-- Text
exec sp_CreateListValue
	@Name = 'LV.StatutLogs.Updated',
	@Description = 'Updated',
	@CustomValue = NULL,
	@ParentName = 'LV.StatutLogs';
GO

-- Text
exec sp_CreateListValue
	@Name = 'LV.StatutLogs.Deleted',
	@Description = 'Deleted',
	@CustomValue = NULL,
	@ParentName = 'LV.StatutLogs';
GO
