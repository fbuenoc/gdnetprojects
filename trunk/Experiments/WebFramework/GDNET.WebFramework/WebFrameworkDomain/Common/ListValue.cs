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
        private IList<ListValue> children = new List<ListValue>();
        private IList<Translation> translations = new List<Translation>();

        #region Properties

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Value
        {
            get;
            set;
        }

        public virtual int Position
        {
            get;
            set;
        }

        public virtual string CodeDescription
        {
            get;
            set;
        }

        public virtual ListValue Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Children of list
        /// </summary>
        public virtual ReadOnlyCollection<ListValue> Children
        {
            get { return new ReadOnlyCollection<ListValue>(this.children); }
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
