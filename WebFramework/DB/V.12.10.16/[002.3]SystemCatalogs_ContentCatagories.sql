exec SP_AddOrUpdateCatalog 'ch.contentcategories', 'Content categories', 1;

exec SP_AddOrUpdateDataLine 'ch.contentcategories', 'itdev', 'Programming', NULL, 'Programming';
exec SP_AddOrUpdateDataLine 'ch.contentcategories', 'itdev.java', 'Java', 'itdev', 'Java';
exec SP_AddOrUpdateDataLine 'ch.contentcategories', 'itdev.net', '.NET (C#, VB.NET)', 'itdev', '.NET (C#, VB.NET)';
exec SP_AddOrUpdateDataLine 'ch.contentcategories', 'itdev.client', 'JavaScript, HTML/CSS', 'itdev', '.NET (C#, VB.NET)';

exec SP_AddOrUpdateDataLine 'ch.contentcategories', 'itman', 'IT Management', NULL, 'IT Management Skills';

GO
