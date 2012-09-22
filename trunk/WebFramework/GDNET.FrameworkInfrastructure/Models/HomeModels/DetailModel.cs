using System.Collections.Generic;
using GDNET.FrameworkInfrastructure.Models.Content;

namespace GDNET.FrameworkInfrastructure.Models.HomeModels
{
    public class DetailModel
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
    }
}
