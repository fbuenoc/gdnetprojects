using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Culture : EntityBase<int>
    {
        private IList<Translation> translations = new List<Translation>();

        #region Properties

        public virtual string CultureCode
        {
            get;
            set;
        }

        public virtual bool IsDefault
        {
            get;
            set;
        }

        public virtual bool IsActive
        {
            get;
            set;
        }

        /// <summary>
        /// All translations by culture
        /// </summary>
        public virtual ReadOnlyCollection<Translation> Translations
        {
            get { return new ReadOnlyCollection<Translation>(this.translations); }
        }

        #endregion

        protected Culture() { }
    }
}
