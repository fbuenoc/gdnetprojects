using System.Collections.Generic;
using GDNET.FrameworkInfrastructure.Common.Models;
using GDNET.FrameworkInfrastructure.Models.Content;

namespace GDNET.FrameworkInfrastructure.Models.HomeModels
{
    public class DetailModel
    {
        public DetailModel()
        {
            this.ItemModel = new ContentItemModel();
            this.FocusItems = new List<ContentItemModel>();
            this.AuthorModel = new UpdateDetailsModel();
        }

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

        public UpdateDetailsModel AuthorModel
        {
            get;
            set;
        }
    }
}
