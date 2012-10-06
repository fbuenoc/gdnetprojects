using GDNET.FrameworkInfrastructure.Models.HomeModels;
using GDNET.FrameworkInfrastructure.Models.System;

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
