using System.Collections.Generic;
using GDNET.FrameworkInfrastructure.Models.Base;
using GDNET.FrameworkInfrastructure.Models.Content;

namespace GDNET.FrameworkInfrastructure.Models.PageModels
{
    public class HomeIndexModel : AbstractPageModel
    {
        public HomeIndexModel()
            : base()
        {
            this.NewItems = new List<ContentItemModel>();
            this.FocusItems = new List<ContentItemModel>();
        }

        public IList<ContentItemModel> NewItems
        {
            get;
            set;
        }

        public IList<ContentItemModel> FocusItems
        {
            get;
            set;
        }
    }
}
