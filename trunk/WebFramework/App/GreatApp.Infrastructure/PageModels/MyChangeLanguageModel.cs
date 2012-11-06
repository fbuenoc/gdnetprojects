using GDNET.Framework.Models;
using GDNET.FrameworkInfrastructure.Models.System;

namespace GDNET.FrameworkInfrastructure.Models.PageModels
{
    public class MyChangeLanguageModel : AbstractPageModel
    {
        public UserCustomizedInformationModel UserCustomizedInformation
        {
            get;
            set;
        }

        public MyChangeLanguageModel()
            : base()
        {
        }
    }
}
