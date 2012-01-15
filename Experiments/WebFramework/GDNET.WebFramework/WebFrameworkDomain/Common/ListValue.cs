using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class ListValue : EntityWithFullInfoBase<long>
    {
        private IList<ListValue> subValues = new List<ListValue>();

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

        #endregion

        #region Methods

        public virtual void AddSubValue(ListValue subValue)
        {
            if (this.SubValues.Contains(subValue))
            {
                return;
            }

            subValue.Parent = this;
            this.subValues.Add(subValue);
        }

        #endregion

        protected ListValue() { }
    }
}
