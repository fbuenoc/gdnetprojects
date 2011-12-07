using WebFramework.Modeles.Framework.Common;
using WebFrameworkDomain.Common;

namespace WebFramework.Modeles.Framework.DomainModels
{
    public sealed class CultureModel : ModelActiveBase<Culture, int>
    {
        #region Ctors

        public CultureModel() : base() { }

        public CultureModel(Culture entity)
            : base(entity)
        {
            this.CultureCode = entity.CultureCode;
        }

        #endregion

        #region Properties

        public string CultureCode
        {
            get;
            set;
        }

        #endregion
    }
}
