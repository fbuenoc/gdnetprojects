using System.Collections.Generic;
using GDNET.FrameworkInfrastructure.Models.Content;

namespace GDNET.FrameworkInfrastructure.Models.HomeModels
{
    public class IndexModel
    {
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
