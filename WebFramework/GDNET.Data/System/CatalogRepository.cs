﻿using System;
using GDNET.Domain.Entities.System;
using GDNET.Domain.Repositories.System;
using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagement;
using GDNET.Utils;

namespace GDNET.Data.System
{
    public class CatalogRepository : AbstractRepository<Catalog, Guid>, ICatalogRepository
    {
        public CatalogRepository(INHibernateRepositoryStrategy strategy)
            : base(strategy)
        {
        }

        public Catalog FindByCode(string code)
        {
            var defaultCatalog = default(Catalog);
            string codeProperty = ExpressionAssistant.GetPropertyName(() => defaultCatalog.Code);

            var listOfCatalogs = base.FindByProperty(codeProperty, code);
            return (listOfCatalogs.Count > 0 ? listOfCatalogs[0] : null);
        }
    }
}
