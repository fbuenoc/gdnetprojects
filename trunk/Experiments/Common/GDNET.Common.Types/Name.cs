using System;
using System.Text;
using GDNET.Common.DesignByContract;
using GDNET.Common.Domain;
using GDNET.Common.Helpers;
using GDNET.Extensions;

namespace GDNET.Common.Types
{
    [Serializable]
    public partial class Name : ISerializable
    {
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

        #region Ctors

        public Name()
        {
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
                if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.LastName))
                {
                    this.LastName = Base64Assistant.Decrypt(pValues[1]);
                }
                else if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.MiddleName))
                {
                    this.MiddleName = Base64Assistant.Decrypt(pValues[1]);
                }
                else if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.FirstName))
                {
                    this.FirstName = Base64Assistant.Decrypt(pValues[1]);
                }
                else if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.DisplayName))
                {
                    this.DisplayName = Base64Assistant.Decrypt(pValues[1]);
                }
                else
                {
                    ThrowException.NotImplementedException(string.Format("Property {0} is not handled.", pValues[0]));
                }
            }
        }

        #endregion

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();
            if (this.LastName != null)
            {
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.LastName), Base64Assistant.Encrypt(this.LastName));
            }
            if (this.MiddleName != null)
            {
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.MiddleName), Base64Assistant.Encrypt(this.MiddleName));
            }
            if (this.FirstName != null)
            {
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.FirstName), Base64Assistant.Encrypt(this.FirstName));
            }
            if (this.DisplayName != null)
            {
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.DisplayName), Base64Assistant.Encrypt(this.DisplayName));
            }

            return sb.ToString();
        }
    }
}
