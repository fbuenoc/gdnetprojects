using System;
using GDNET.Common.Base.Entities;

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
        }
    }
}
