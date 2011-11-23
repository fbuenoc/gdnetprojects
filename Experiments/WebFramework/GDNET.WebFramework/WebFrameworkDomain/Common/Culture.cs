﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using GDNET.Common.Base.Entities;

namespace WebFrameworkDomain.Common
{
    public partial class Culture : EntityBase<string>
    {
        private IList<Translation> translations = new List<Translation>();

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

        /// <summary>
        /// All translations by culture
        /// </summary>
        public virtual ReadOnlyCollection<Translation> Translations
        {
            get { return new ReadOnlyCollection<Translation>(this.translations); }
        }

        protected Culture() { }
    }
}
