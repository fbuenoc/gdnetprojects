using GDNET.FrameworkInfrastructure.Models.Base;
using GDNET.FrameworkInfrastructure.Models.System;

namespace GDNET.FrameworkInfrastructure.Models.My
{
    public class ChangeLanguageModel : AbstractPageModel
    {
        public UserCustomizedInformationModel UserCustomizedInformation
        {
            get;
            set;
        }

        public ChangeLanguageModel()
            : base()
        {
        }
    }
}
