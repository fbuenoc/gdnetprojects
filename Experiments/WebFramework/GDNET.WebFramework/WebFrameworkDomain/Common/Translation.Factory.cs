using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;

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

            public Translation Create(string code, string value)
            {
                Throw.ArgumentExceptionIfNullOrEmpty(code, "code", "Code of translation can not be nullable.");

                var translation = this.Create();
                translation.Code = code;
                translation.Value = value;

                return translation;
            }
        }
    }
}
