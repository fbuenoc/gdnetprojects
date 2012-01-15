using System.Collections.Generic;
using System.Collections.ObjectModel;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Application : EntityWithFullInfoBase<long>
    {
        private IList<ContentType> contentTypes = new List<ContentType>();

        #region Properties

        public virtual Translation Name
        {
            get;
            set;
        }

        public virtual Translation Description
        {
            get;
            set;
        }

        public virtual ListValue Category
        {
            get;
            set;
        }

        public virtual Culture CultureDefault
        {
            get;
            set;
        }

        public virtual string RootUrl
        {
            get;
            set;
        }

        public virtual ReadOnlyCollection<ContentType> ContentTypes
        {
            get { return new ReadOnlyCollection<ContentType>(this.contentTypes); }
        }

        #endregion

        protected Application() { }

    }
}
