﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebFramework.Modeles.Framework.Base;
using WebFrameworkDomain.Common;

namespace WebFramework.Modeles.Framework.Common
{
    public sealed class ApplicationModel : ModelWithModificationBase<Application, long>
    {
        #region Properties

        [Required]
        [DisplayName("Application name")]
        public string Name
        {
            get;
            set;
        }

        [DisplayName("Description")]
        public string Description
        {
            get;
            set;
        }

        [DisplayName("Category")]
        public string Category
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Root Url (without http://)")]
        public string RootUrl
        {
            get;
            set;
        }

        #endregion

        #region Ctors

        public ApplicationModel()
            : base()
        { }

        public ApplicationModel(Application application)
            : base(application)
        {
            this.Name = (base.Entity.Name == null) ? string.Empty : base.Entity.Name.Value;
            this.Description = (base.Entity.Description == null) ? string.Empty : base.Entity.Description.Value;
            this.Category = (base.Entity.Category.Description == null) ? string.Empty : base.Entity.Category.Description.Value;
            this.RootUrl = base.Entity.RootUrl.StartsWith("http://") ? base.Entity.RootUrl : string.Format("http://{0}", base.Entity.RootUrl);
        }

        #endregion
    }
}