using System;
using GDNET.Common.DesignByContract;
using WebFramework.Domain.Constants;

namespace WebFramework.Domain.Common
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
                ThrowException.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of translation can not be nullable.");

                var translation = new Translation
                {
                    Code = code,
                    Value = value,
                    Culture = culture
                };
                translation.LifeCycle.AddStatutLog(StatutLog.Factory.Create(string.Empty));

                return translation;
            }

            public Translation NewInstance()
            {
                return new Translation();
            }
        }
    }
}
