using GDNET.FrameworkInfrastructure.Common.Models;
using GDNET.FrameworkInfrastructure.Models.HomeModels;

namespace GDNET.FrameworkInfrastructure.Models.SearchModels
{
    public class SearchByAuthorModel : IndexModel
    {
        public SearchByAuthorModel(SearchMode mode)
            : base()
        {
            this.Mode = mode;
            this.AuthorModel = new UserDetailsModel();
        }

        public SearchMode Mode
        {
            get;
            set;
        }

        public UserDetailsModel AuthorModel
        {
            get;
            set;
        }
    }
}
