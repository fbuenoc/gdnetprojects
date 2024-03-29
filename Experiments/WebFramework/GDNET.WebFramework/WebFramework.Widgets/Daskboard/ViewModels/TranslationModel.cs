﻿using System.ComponentModel.DataAnnotations;
using WebFramework.Common.ComponentModel;
using WebFramework.Domain.Common;
using WebFramework.Widgets.Daskboard.Base;

namespace WebFramework.Widgets.Daskboard.ViewModels
{
    public sealed class TranslationModel : ModelEntityWithLifeCycleBase<Translation, long>
    {
        #region Properties

        public ListValueModel Category
        {
            get;
            protected set;
        }

        [RequiredML]
        [DisplayNameML("")]
        public int CultureId
        {
            get;
            set;
        }

        [RequiredML]
        [DisplayNameML("")]
        public string CultureCode
        {
            get;
            set;
        }

        [DisplayNameML("SysTranslation.Description")]
        public string Code
        {
            get;
            set;
        }

        [Required]
        [DisplayNameML("")]
        public string Value
        {
            get;
            set;
        }

        #endregion

        #region Ctors

        public TranslationModel()
            : base()
        { }

        public TranslationModel(Translation translation)
            : base(translation)
        {
            this.Code = translation.Code;
            this.Value = translation.Value;

            this.CultureId = translation.Culture.Id;
            this.CultureCode = translation.Culture.CultureCode;

            if (translation.Category != null)
            {
                this.Category = new ListValueModel(translation.Category);
            }
        }

        #endregion
    }
}
