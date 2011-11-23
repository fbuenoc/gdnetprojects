using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Translation
    {
        public static TranslationFactory Factory
        {
            get { return new TranslationFactory(); }
        }

        public class TranslationFactory
        {
            /// <summary>
            /// Create a translation with default values
            /// </summary>
            /// <returns></returns>
            public Translation Create()
            {
                var result = new Translation
                {
                    IsActive = true,
                    IsDeletable = true,
                    IsEditable = true,
                    IsViewable = true,
                };

                return result;
            }
        }
    }
}
