﻿using System.Collections.Generic;
using System.Linq;
using WebFramework.Common.Framework.Base;
using WebFramework.Domain.System;

namespace WebFramework.Widgets.Daskboard.ViewModels
{
    public sealed class WidgetModel : ModelEntityWithLifeCycleBase<Widget, long>
    {
        public string Code
        {
            get;
            set;
        }

        public string TechnicalName
        {
            get;
            set;
        }

        public string ClassName
        {
            get;
            set;
        }

        public string AssemblyName
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Version
        {
            get;
            set;
        }

        public IList<WidgetPropertyModel> PropertiesModel
        {
            get
            {
                List<WidgetPropertyModel> listProperties = new List<WidgetPropertyModel>();
                if (base.Entity != null)
                {
                    listProperties.AddRange(base.Entity.Properties.Select(x => new WidgetPropertyModel(x)));
                }
                return listProperties;
            }
        }

        public WidgetModel()
            : base()
        {
        }

        public WidgetModel(Widget entity)
            : base(entity)
        {
            this.Code = entity.Code;
            this.TechnicalName = entity.TechnicalName;
            this.ClassName = entity.ClassName;
            this.AssemblyName = entity.AssemblyName;
            this.Version = entity.Version;
            this.Name = entity.Name.Value;
            this.Description = entity.Description.Value;
        }
    }
}