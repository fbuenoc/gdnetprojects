using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;
using WebFrameworkDomain.Common.Constants;
using WebFrameworkDomain.DefaultImpl;
using System;

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
            public Translation Create()
            {
                var result = new Translation
                {
                    IsActive = true,
                    IsDeletable = true,
                    IsEditable = true,
                    IsGeneric = false,
                    IsViewable = true,
                };

                return result;
            }

            /// <summary>
            /// Create a translation with default culture code
            /// </summary>
            public Translation Create(string value)
            {
                return this.Create(Guid.NewGuid().ToString(), value);
            }

            /// <summary>
            /// Create a translation with default culture code
            /// </summary>
            public Translation Create(string code, string value)
            {
                return this.Create(code, value, CommonConstants.CultureCodeDefault);
            }

            /// <summary>
            /// Create a translation with a culture code
            /// </summary>
            public Translation Create(string code, string value, string cultureCode)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(cultureCode, "cultureCode", "Code culture of translation can not be nullable.");
                Culture culture = DomainRepositories.Culture.FindByCode(cultureCode);
                return this.Create(code, value, culture);
            }

            /// <summary>
            /// Create a translation with a Culture
            /// </summary>
            public Translation Create(string code, string value, Culture culture)
            {
                return this.Create(code, value, culture, false);
            }

            /// <summary>
            /// Create a translation with a Culture
            /// </summary>
            public Translation Create(string code, string value, Culture culture, bool isGeneric)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of translation can not be nullable.");

                var translation = this.Create();
                translation.Code = code;
                translation.Value = value;
                translation.Culture = culture;
                translation.IsGeneric = isGeneric;

                return translation;
            }
        }
    }
}
