using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;

namespace WebFrameworkDomain.Common
{
    public partial class ContentAttribute
    {
        public static ContentAttributeFactory Factory
        {
            get { return new ContentAttributeFactory(); }
        }

        public class ContentAttributeFactory
        {
            /// <summary>
            /// Create new content attribute with all flags are on.
            /// </summary>
            /// <returns></returns>
            public ContentAttribute Create()
            {
                return new ContentAttribute
                {
                    IsActive = true,
                    IsDeletable = true,
                    IsEditable = true,
                    IsViewable = true,
                };
            }

            public ContentAttribute Create(string code)
            {
                return this.Create(code, 0);
            }

            public ContentAttribute Create(string code, int position)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of attribute can not be nullable.");

                var attribute = this.Create();
                attribute.Code = code;
                attribute.Position = position;

                return attribute;
            }
        }
    }
}
