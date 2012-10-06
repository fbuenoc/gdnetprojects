using System.Collections.Generic;
using GDNET.FrameworkInfrastructure.Models.Base;
using GDNET.FrameworkInfrastructure.Models.Content;
using GDNET.FrameworkInfrastructure.Models.System;

namespace GDNET.FrameworkInfrastructure.Models.PageModels
{
    public class HomeDetailModel : AbstractPageModel
    {
        public ContentItemModel ItemModel
        {
            get;
            set;
        }

        public IList<ContentItemModel> FocusItems
        {
            get;
            set;
        }

        public UserDetailsModel AuthorModel
        {
            get;
            set;
        }

        public HomeDetailModel()
            : base()
        {
            this.ItemModel = new ContentItemModel();
            this.FocusItems = new List<ContentItemModel>();
            this.AuthorModel = new UserDetailsModel();
        }
    }
}
