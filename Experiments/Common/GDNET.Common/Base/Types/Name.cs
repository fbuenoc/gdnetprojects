using System;
using System.Text;

using GDNET.Common.Domain;
using GDNET.Common.DesignByContract;

namespace GDNET.Common.Base.Types
{
    [Serializable]
    public class Name : ISrerializable
    {
        private const string PropertyFirstName = "b1426c45-b1cd-4cb0-a9ca-e373ae2cff66";
        private const string PropertyLastName = "bc0cb852-bd89-4d75-a003-caf8b54b50c1";
        private const string PropertyMiddleName = "cc790035-1f41-4b00-8c98-108a4864638c";
        private const string PropertyDisplayName = "81753a67-61d9-480c-b0ee-e4e4e897ff7e";

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }

        public Name(string serializedName)
        {
            foreach (var propertyValues in serializedName.Split(';'))
            {
                if (string.IsNullOrEmpty(propertyValues))
                {
                    continue;
                }

                var pValues = propertyValues.Split(':');
                switch (pValues[0])
                {
                    case PropertyLastName:
                        this.LastName = pValues[1];
                        break;

                    case PropertyMiddleName:
                        this.MiddleName = pValues[1];
                        break;

                    case PropertyFirstName:
                        this.FirstName = pValues[1];
                        break;

                    case PropertyDisplayName:
                        this.DisplayName = pValues[1];
                        break;

                    default:
                        ThrowException.NotImplementedException(string.Format("Property {0} is not handled", pValues[0]));
                        break;
                }
            }
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:{1};", PropertyLastName, this.LastName);
            sb.AppendFormat("{0}:{1};", PropertyMiddleName, this.MiddleName);
            sb.AppendFormat("{0}:{1};", PropertyFirstName, this.FirstName);
            sb.AppendFormat("{0}:{1};", PropertyDisplayName, this.DisplayName);

            return sb.ToString();
        }
    }
}
