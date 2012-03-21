using System;
using GDNET.Common.Security.DefaultImpl;
using WebFramework.Domain.Constants;

namespace WebFramework.Domain.Common
{
    public partial class StatutLog
    {
        public static StatutLogFactory Factory
        {
            get { return new StatutLogFactory(); }
        }

        public class StatutLogFactory
        {
            public StatutLog Create(string description)
            {
                ListValue statut = DomainRepositories.ListValue.FindByName(ListValueConstants.StatutLogs.Created);
                return this.Create(description, SessionService.Instance.User.Identity.Name, DateTime.Now, statut);
            }

            public StatutLog Create(string description, string createdBy, DateTime date, ListValue statut)
            {
                return new StatutLog
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = date,
                    CreatedBy = createdBy,
                    Statut = statut,
                    Description = description,
                };
            }
        }
    }
}
