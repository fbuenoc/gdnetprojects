using System;

using GDNET.Common.Adapters;
using GDNET.Web.MultilingualControls;

namespace GDNET.Web.Adapters
{
    public class AdapterLiteral : IAdapterLiteral
    {
        private Literal literal;

        public AdapterLiteral(Literal literal)
        {
            this.literal = literal;
        }

        #region IAdapterHyperLink Members

        public string Text
        {
            get { return this.literal.Text; }
            set { this.literal.Text = value; }
        }

        public string TextCode
        {
            get { return this.literal.TextCode; }
            set { this.literal.TextCode = value; }
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        public bool Enable
        {
            get;
            set;
        }

        public bool Visible
        {
            get { return this.literal.Visible; }
            set { this.literal.Visible = value; }
        }

        #endregion

    }
}
