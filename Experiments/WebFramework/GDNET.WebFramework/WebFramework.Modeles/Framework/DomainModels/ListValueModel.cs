using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebFramework.Modeles.Framework.Common;
using WebFrameworkDomain.Common;

namespace WebFramework.Modeles.Framework.DomainModels
{
    public sealed class ListValueModel : ModelFullControlBase<ListValue, long>
    {
        #region Properties

        [Required]
        [DisplayName("Value name")]
        public string Name
        {
            get;
            set;
        }

        [Required]
        [DisplayName("Description")]
        public string Description
        {
            get;
            set;
        }

        [DisplayName("Custom value")]
        public string CustomValue
        {
            get;
            set;
        }

        [DisplayName("Parent")]
        public string Parent
        {
            get;
            set;
        }

        [DisplayName("Position")]
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
            if (base.Entity.Parent != null)
            {
                this.UpdateParent(base.Entity.Parent);
            }
        }

        #endregion

    }
}
