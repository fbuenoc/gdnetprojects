using GDNET.NHibernate.Repositories;
using GDNET.NHibernate.SessionManagers;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Repositories.System;
using WebFramework.Domain.System;

namespace WebFramework.Data.System.Repositories
{
    public class WidgetRepository : AbstractRepository<Widget, long>, IWidgetRepository
    {
        public WidgetRepository(ISessionStrategy sessionStrategy)
            : base(sessionStrategy)
        {
        }

        public Widget GetByCode(string widgetCode)
        {
            var widgets = this.FindByProperty(MetaInfos.WidgetMeta.Code, widgetCode);
            if (widgets.Count == 1)
            {
                return widgets[0];
            }

            return null;
        }
    }
}
