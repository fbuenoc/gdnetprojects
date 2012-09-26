using System.Collections.Generic;
using GDNET.FrameworkInfrastructure.Common.Models;
using GDNET.FrameworkInfrastructure.Models.Base;
using GDNET.FrameworkInfrastructure.Models.Content;

namespace GDNET.FrameworkInfrastructure.Models.HomeModels
{
    public class DetailModel : AbstractPageModel
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

        public DetailModel()
            : base()
        {
            this.ItemModel = new ContentItemModel();
            this.FocusItems = new List<ContentItemModel>();
            this.AuthorModel = new UserDetailsModel();
        }
    }
}
