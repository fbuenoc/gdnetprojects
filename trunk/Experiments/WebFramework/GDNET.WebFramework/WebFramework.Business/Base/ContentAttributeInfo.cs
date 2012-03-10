namespace WebFramework.Business.Base
{
    public sealed class ContentAttributeInfo
    {
        public int Position
        {
            get;
            set;
        }

        public string PropertyName
        {
            get;
            set;
        }

        public string ContentDataType
        {
            get;
            set;
        }

        public ContentAttributeInfo(string propertyName, string contentDataType, int position)
        {
            this.PropertyName = propertyName;
            this.ContentDataType = contentDataType;
            this.Position = position;
        }
    }
}
