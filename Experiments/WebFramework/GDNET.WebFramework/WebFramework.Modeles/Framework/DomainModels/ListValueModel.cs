using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using GDNET.Common.Base.Entities;
using GDNET.Common.DesignByContract;

using WebFramework.Modeles.Framework.Common;

using WebFrameworkDomain.Common;
using WebFrameworkDomain.DefaultImpl;

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
                this.Parent = base.Entity.Parent.Name;
                this.ParentId = base.Entity.Parent.Id;
            }
        }

        #endregion

    }
}
