using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ListValue : EntityFullControlBase<long>
    {
        private IList<ListValue> subValues = new List<ListValue>();
        private IList<Translation> translations = new List<Translation>();

        #region Properties

        public virtual Translation Description
        {
            get;
            set;
        }

        public virtual ListValue Parent
        {
            get;
            set;
        }

        public virtual Application Application
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string CustomValue
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            set;
        }

        /// <summary>
        /// Children
        /// </summary>
        public virtual ReadOnlyCollection<ListValue> SubValues
        {
            get { return new ReadOnlyCollection<ListValue>(this.subValues); }
        }

        /// <summary>
        /// All translations belong to this category
        /// </summary>
        public virtual ReadOnlyCollection<Translation> Translations
        {
            get { return new ReadOnlyCollection<Translation>(this.translations); }
        }

        #endregion

        protected ListValue() { }
    }
}
