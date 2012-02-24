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
            public ContentAttribute Create(string code, long contentTypeId, string dataTypeName)
            {
                return this.Create(code, contentTypeId, dataTypeName, 0);
            }

            public ContentAttribute Create(string code, long contentTypeId, string dataTypeName, int position)
            {
                var contentType = DomainRepositories.ContentType.GetById(contentTypeId);
                var dataType = DomainRepositories.ListValue.FindByName(dataTypeName);
                return this.Create(code, contentType, dataType, position);
            }

            public ContentAttribute Create(string code, ContentType type, ListValue dataType, int position)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of attribute can not be null.");
                ThrowException.ArgumentNullException(dataType, "dataType", "Data type can not be null.");

                var attribute = new ContentAttribute
                {
                    Code = code,
                    Position = position
                };

                attribute.ContentType = type;
                attribute.DataType = dataType;
                attribute.LifeCycle.AddStatutLog(StatutLog.Factory.Create("BF"));

                return attribute;
            }

        }
    }
}
