using System.ComponentModel;
using WebFramework.Domain;

namespace WebFramework.Common.ComponentModel
{
    public class DisplayNameML : DisplayNameAttribute
    {
        private string translationCode;
        private string translationValue;

        public DisplayNameML(string translationCode)
            : base(translationCode)
        {
            this.translationCode = translationCode;
        }

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(translationValue))
                {
                    var translation = DomainRepositories.Translation.GetByCode(this.translationCode);
                    if (translation != null)
                    {
                        this.translationValue = translation.Value;
                    }
                }

                return this.translationValue;
            }
        }
    }
}
