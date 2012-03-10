using System;
using GDNET.Common.DesignByContract;
using WebFramework.Domain.Constants;
using WebFramework.Domain.DefaultImpl;

namespace WebFramework.Domain.Common
{
    public partial class Temporary
    {
        public static TemporaryFactory Factory
        {
            get { return new TemporaryFactory(); }
        }

        public sealed class TemporaryFactory
        {
            /// <summary>
            /// Create Temporary data with default encoding (NONE)
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public Temporary Create(string value)
            {
                return this.Create(value, ListValueConstants.EncryptionTypes.None);
            }

            /// <summary>
            /// Create Temporary data with base64 encoding
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public Temporary CreateWithBase64(string value)
            {
                return this.Create(value, ListValueConstants.EncryptionTypes.Base64);
            }

            /// <summary>
            /// Create Temporary data with AES encryption
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public Temporary CreateWithAES(string value)
            {
                return this.Create(value, ListValueConstants.EncryptionTypes.AES);
            }

            public Temporary Create(string value, string encodingTypeName)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(encodingTypeName, "encodingTypeName", "Encoding type name can not be null.");

                var temporary = new Temporary
                {
                    Id = Guid.NewGuid(),
                    Text = value,
                };

                temporary.EncryptionType = DomainRepositories.ListValue.FindByName(encodingTypeName);
                temporary.LifeCycle.AddStatutLog(StatutLog.Factory.Create("BF"));

                return temporary;
            }
        }
    }
}
