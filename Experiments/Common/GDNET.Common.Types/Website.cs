using System;
using System.Text;
using GDNET.Common.DesignByContract;
using GDNET.Common.Domain;
using GDNET.Common.Helpers;
using GDNET.Extensions;

namespace GDNET.Common.Types
{
    [Serializable]
    public class Website : ISerializable
    {
        public string SiteName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public Website() { }

        public Website(string serializedWebsite)
        {
            foreach (var propertyValues in serializedWebsite.Split(';'))
            {
                if (string.IsNullOrEmpty(propertyValues))
                {
                    continue;
                }

                var pValues = propertyValues.Split(':');
                if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.SiteName))
                {
                    this.SiteName = Base64Assistant.Decrypt(pValues[1]);
                }
                else if (pValues[0] == ExpressionAssistant.GetPropertyName(() => this.Address))
                {
                    this.Address = Base64Assistant.Decrypt(pValues[1]);
                }
                else
                {
                    ThrowException.NotImplementedException(string.Format("Property {0} is not handled.", pValues[0]));
                }
            }
        }

        public string Serialize()
        {
            StringBuilder sb = new StringBuilder();

            if (this.SiteName != null)
            {
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.SiteName), Base64Assistant.Encrypt(this.SiteName));
            }
            if (this.Address != null)
            {
                sb.AppendFormat("{0}:{1};", ExpressionAssistant.GetPropertyName(() => this.Address), Base64Assistant.Encrypt(this.Address));
            }

            return sb.ToString();
        }
    }
}
