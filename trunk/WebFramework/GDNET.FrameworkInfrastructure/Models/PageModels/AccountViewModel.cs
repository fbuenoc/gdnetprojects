using System.Collections.Generic;
using GDNET.FrameworkInfrastructure.Models.Base;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Models.System;

namespace GDNET.FrameworkInfrastructure.Models.PageModels
{
    public sealed class AccountViewModel : AbstractPageModel
    {
        public UserDetailsModel UserDetails
        {
            get;
            set;
        }

        public IList<ContentItemModel> FocusItems
        {
            get;
            set;
        }

        public AccountViewModel()
            : base()
        {
            this.UserDetails = new UserDetailsModel();
            this.FocusItems = new List<ContentItemModel>();
        }
    }
}
