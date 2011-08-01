using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.ViewModels;

namespace GDNET.ElapsedTimeField.Settings
{
    public class ElapsedTimeFieldEditorEvents : ContentDefinitionEditorEventsBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="definition"></param>
        /// <returns></returns>
        public override IEnumerable<TemplateViewModel> PartFieldEditor(ContentPartFieldDefinition definition)
        {
            if (definition.FieldDefinition.Name == Constants.ElapsedTimeField)
            {
                var model = definition.Settings.GetModel<ElapsedTimeFieldSettings>();
                yield return DefinitionTemplate(model);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="updateModel"></param>
        /// <returns></returns>
        public override IEnumerable<TemplateViewModel> PartFieldEditorUpdate(ContentPartFieldDefinitionBuilder builder, IUpdateModel updateModel)
        {
            var model = new ElapsedTimeFieldSettings();
            if (updateModel.TryUpdateModel(model, Constants.ElapsedTimeFieldSettings, null, null))
            {
                builder.WithSetting("ElapsedTimeFieldSettings.Display", model.Display.ToString());
            }

            yield return DefinitionTemplate(model);
        }
    }
}