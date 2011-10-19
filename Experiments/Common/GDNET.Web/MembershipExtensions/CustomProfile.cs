using System.Web.Profile;
using GDNET.Web.MembershipExtensions.Objects;

namespace GDNET.Web.MembershipExtensions
{
    /// <summary>
    /// The custom profile
    /// </summary>
    public class CustomProfile : ProfileBase
    {
        /// <summary>
        /// Basic information of a user
        /// </summary>
        public CommonInformation BasicInformation
        {
            get
            {
                return (CommonInformation)base.GetPropertyValue("BasicInformation");
            }
            set
            {
                base.SetPropertyValue("BasicInformation", value);
            }
        }
    }
}
