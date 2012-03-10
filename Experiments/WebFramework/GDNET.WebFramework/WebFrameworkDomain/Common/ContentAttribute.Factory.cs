using GDNET.Common.DesignByContract;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Domain.Common
{
    public partial class ContentAttribute
    {
        public static ContentAttributeFactory Factory
        {
            get { return new ContentAttributeFactory(); }
        }

        public class ContentAttributeFactory
        {
            public ContentAttribute Create(string code, string name, string dataTypeName, long contentTypeId)
            {
                return this.Create(code, name, dataTypeName, contentTypeId, int.MaxValue);
            }

            public ContentAttribute Create(string code, string name, string dataTypeName, long contentTypeId, int position)
            {
                var contentType = DomainRepositories.ContentType.GetById(contentTypeId);
                var dataType = DomainRepositories.ListValue.FindByName(dataTypeName);
                return this.Create(code, name, contentType, dataType, position);
            }

            public ContentAttribute Create(string code, string name, ContentType type, ListValue dataType, int position)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of attribute can not be null.");
                ThrowException.ArgumentNullException(dataType, "dataType", "Data type can not be null.");

                var attribute = new ContentAttribute
                {
                    Code = code,
                    Position = position,
                    Name = Translation.Factory.Create(name),
                };

                attribute.ContentType = type;
                attribute.DataType = dataType;
                attribute.LifeCycle.AddStatutLog(StatutLog.Factory.Create("BF"));

                return attribute;
            }

        }
    }
}
