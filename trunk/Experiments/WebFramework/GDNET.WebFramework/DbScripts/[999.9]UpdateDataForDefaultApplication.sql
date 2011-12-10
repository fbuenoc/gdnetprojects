-- Set all available LV/LVH to default application
update [dbo].[ListValue] set [ApplicationId] = (
	select [Id] from [dbo].[Application] where [RootUrl] = '*'
)
GO

---- From now on, the [ApplicationId] is not nullable.
--alter table [dbo].[ListValue]
--alter column [ApplicationId] bigint null;
--GO

