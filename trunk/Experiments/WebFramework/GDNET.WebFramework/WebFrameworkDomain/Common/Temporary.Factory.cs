using System;

using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;

using WebFrameworkDomain.DefaultImpl;
using WebFrameworkDomain.Common.Constants;

namespace WebFrameworkDomain.Common
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
            /// Create temporary item
            /// </summary>
            /// <returns></returns>
            public Temporary Create()
            {
                return new Temporary
                {
                    IsActive = true,
                    Id = Guid.NewGuid().ToString(),
                };
            }

            /// <summary>
            /// Create Temporary data with default encoding (NONE)
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public Temporary Create(string value)
            {
                return this.Create(value, ListValueConstants.EncryptionTypes_None);
            }

            /// <summary>
            /// Create Temporary data with base64 encoding
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public Temporary CreateWithBase64(string value)
            {
                return this.Create(value, ListValueConstants.EncryptionTypes_Base64);
            }

            /// <summary>
            /// Create Temporary data with AES encryption
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public Temporary CreateWithAES(string value)
            {
                return this.Create(value, ListValueConstants.EncryptionTypes_AES);
            }

            public Temporary Create(string value, string encodingTypeName)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(encodingTypeName, "encodingTypeName", "Encoding type name can not be null.");

                var temporary = this.Create();

                temporary.Text = value;
                temporary.EncryptionType = DomainRepositories.ListValue.FindByName(encodingTypeName);

                return temporary;
            }
        }
    }
}
