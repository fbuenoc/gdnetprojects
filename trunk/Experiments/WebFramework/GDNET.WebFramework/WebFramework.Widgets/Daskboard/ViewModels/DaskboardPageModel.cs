using WebFramework.Common.Framework.System;
using WebFramework.Common.Security;
using WebFramework.Domain.System;
using WebFramework.Widgets.Daskboard.Controllers;

namespace WebFramework.Widgets.Daskboard.ViewModels
{
    public class DaskboardPageModel : PageModel, ISecuredModel
    {
        public DaskboardPageModel()
            : base()
        {
        }

        public DaskboardPageModel(Page entity)
            : base(entity)
        {
        }

        public bool CanAdminister
        {
            get
            {
                return (new AuthorizationService()).ActionIsAllowedForUser(typeof(PageAdminController).FullName, PageAdminController.ActionEdit);
            }
        }
    }
}