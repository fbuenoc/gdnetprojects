using System.Collections.Generic;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Domain.FileWg.Repositories
{
    public class FileContentRepository : AbstractRepository<FileContent, long>, IFileContentRepository
    {
        public FileContentRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public IList<FileContent> GetAllByRegion(Region region)
        {
            return base.GetAll(x => x.AttachedRegions.Contains(region));
        }
    }
}