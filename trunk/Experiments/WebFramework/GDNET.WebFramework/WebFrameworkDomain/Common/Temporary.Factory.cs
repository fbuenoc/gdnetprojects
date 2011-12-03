using System;
using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using WebFrameworkDomain.DefaultImpl;

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

            public Temporary Create(string value, string encodingTypeName)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(encodingTypeName, "encodingTypeName", "Encoding type name can not be null.");

                var temporary = this.Create();

                temporary.Text = value;
                temporary.EncodingType = DomainRepositories.ListValue.FindByName(encodingTypeName);

                return temporary;
            }
        }
    }
}
