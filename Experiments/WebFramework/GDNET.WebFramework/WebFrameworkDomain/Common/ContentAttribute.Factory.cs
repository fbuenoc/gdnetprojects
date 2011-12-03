using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using WebFrameworkDomain.DefaultImpl;

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

            public ContentAttribute Create(string code, ContentType type, string dataTypeCode)
            {
                return this.Create(code, 0, type, dataTypeCode);
            }

            public ContentAttribute Create(string code, int position, ContentType type, string dataTypeName)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of attribute can not be null.");
                Throw.ArgumentExceptionIfNullOrEmpty(dataTypeName, "dataTypeCode", "Code of data type can not be null.");

                var attribute = this.Create();

                attribute.ContentType = type;
                attribute.DataType = DomainRepositories.ListValue.FindByName(dataTypeName);
                attribute.Code = code;
                attribute.Position = position;

                return attribute;
            }
        }
    }
}
