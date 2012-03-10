using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebFramework.Base.Framework.Base;
using WebFrameworkDomain.Common;
using WebFrameworkServices.ComponentModel;

namespace WebFramework.Base.Framework.Common
{
    public sealed class ListValueModel : ModelWithModificationBase<ListValue, long>
    {
        #region Properties

        [Required]
        [DisplayNameML("ApplicationCategories.SysTranslation.Name")]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [DisplayNameML("ApplicationCategories.SysTranslation.Description")]
        public string Description
        {
            get;
            set;
        }

        [DisplayNameML("ApplicationCategories.SysTranslation.Detail")]
        public string Detail
        {
            get;
            set;
        }

        [DisplayNameML("ApplicationCategories.SysTranslation.CustomValue")]
        public string CustomValue
        {
            get;
            set;
        }

        [DisplayNameML("ApplicationCategories.SysTranslation.Parent")]
        public string Parent
        {
            get;
            set;
        }

        [DisplayNameML("ApplicationCategories.SysTranslation.Position")]
        public int Position
        {
            get;
            set;
        }

        public long ParentId
        {
            get;
            set;
        }

        public IEnumerable<ListValueModel> SubValues
        {
            get
            {
                List<ListValueModel> listOfSubValues = new List<ListValueModel>();

                if (base.Entity != null)
                {
                    listOfSubValues.AddRange(base.Entity.SubValues.Select(x => new ListValueModel(x)));
                }

                return listOfSubValues;
            }
        }

        #endregion

        #region Methods

        public void UpdateParent(ListValue parent)
        {
            this.Parent = parent.Name;
            this.ParentId = parent.Id;
        }

        public void UpdateParent(ListValueModel parentModel)
        {
            this.Parent = parentModel.Name;
            this.ParentId = parentModel.Id;
        }

        #endregion

        #region Ctors

        public ListValueModel()
            : base()
        {
        }

        public ListValueModel(ListValue listValue)
            : base(listValue)
        {
            this.Name = base.Entity.Name;
            this.Position = base.Entity.Position;
            this.CustomValue = base.Entity.CustomValue;

            if (base.Entity.Description != null)
            {
                this.Description = base.Entity.Description.Value;
            }
            if (base.Entity.Detail != null)
            {
                this.Detail = base.Entity.Detail.Value;
            }
            if (base.Entity.Parent != null)
            {
                this.UpdateParent(base.Entity.Parent);
            }
        }

        #endregion

    }
}
