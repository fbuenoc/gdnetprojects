using System;
using GDNET.Common.Security.DefaultImpl;
using WebFramework.Domain.Constants;
using WebFramework.Domain.DefaultImpl;

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
                return this.Create(SessionService.Instance.User.Identity.Name, description, DateTime.Now, statut);
            }

            public StatutLog Create(string createdBy, ListValue statut)
            {
                return this.Create(createdBy, string.Empty, DateTime.Now, statut);
            }

            public StatutLog Create(string createdBy, string description, DateTime date, ListValue statut)
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
