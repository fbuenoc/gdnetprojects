using System;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;

namespace GDNET.Data.System
{
    public class TranslationRepository : AbstractRepository<Translation, Guid>, ITranslationRepository
    {
        public TranslationRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }
    }
}
