using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

using GDNET.ElapsedTimeField.Settings;
using GDNET.ElapsedTimeField.ViewModels;
using System.Text;

namespace GDNET.ElapsedTimeField.Drivers
{
    public class ElapsedTimeFieldDriver : ContentFieldDriver<Fields.ElapsedTimeField>
    {
        public IOrchardServices Services { get; set; }

        // EditorTemplates/Fields/Custom.ElapsedTimeField.cshtml
        private const string TemplateName = "Fields/Custom.ElapsedTimeField";

        public Localizer T { get; set; }

        public ElapsedTimeFieldDriver(IOrchardServices services)
        {
            Services = services;
            T = NullLocalizer.Instance;
        }

        private static string GetPrefix(ContentField field, ContentPart part)
        {
            // handles spaces in field names
            return (part.PartDefinition.Name + "." + field.Name).Replace(" ", "_");
        }

        /// <summary>
        /// Displays values
        /// </summary>
        /// <param name="part"></param>
        /// <param name="field"></param>
        /// <param name="displayType"></param>
        /// <param name="shapeHelper"></param>
        /// <returns></returns>
        protected override DriverResult Display(ContentPart part, Fields.ElapsedTimeField field, string displayType, dynamic shapeHelper)
        {
            var settings = field.PartFieldDefinition.Settings.GetModel<ElapsedTimeFieldSettings>();
            var value = field.ElapsedTime;

            if (settings.Display == ElapsedTimeFieldDisplay.MeaningValueOnly)
            {
                var viewModel = Helper.ParseValue(field.ElapsedTime);
                StringBuilder sb = new StringBuilder();
                if (viewModel.Years > 0)
                {
                    sb.AppendFormat("{0}y ", viewModel.Years);
                }
                if (viewModel.Months > 0)
                {
                    sb.AppendFormat("{0}m ", viewModel.Months);
                }
                if (viewModel.Days > 0)
                {
                    sb.AppendFormat("{0}d ", viewModel.Days);
                }
                if (viewModel.Hours > 0)
                {
                    sb.AppendFormat("{0}h ", viewModel.Hours);
                }
                if (viewModel.Minutes > 0)
                {
                    sb.AppendFormat("{0}m ", viewModel.Minutes);
                }

                if (sb.Length > 0)
                {
                    value = sb.ToString().Substring(0, sb.Length - 1);
                }
            }

            return ContentShape(
                // key in Shape Table
                "Fields_Custom_ElapsedTimeField",
                // used to differentiate shapes in placement.info overrides, e.g. Fields_Common_Text-DIFFERENTIATOR
                // this is the actual Shape which will be resolved
                // (Fields/Custom.ElapsedTimeField.cshtml)
                field.Name,
                s => s.Name(field.Name)
                      .ElapsedTime(value)
            );
        }

        /// <summary>
        /// Show edit form
        /// </summary>
        /// <param name="part"></param>
        /// <param name="field"></param>
        /// <param name="shapeHelper"></param>
        /// <returns></returns>
        protected override DriverResult Editor(ContentPart part, Fields.ElapsedTimeField field, dynamic shapeHelper)
        {
            var viewModel = new ElapsedTimeFieldViewModel
            {
                Name = field.Name,
                Data = Helper.ParseValue(field.ElapsedTime)
            };

            return ContentShape("Fields_Custom_ElapsedTimeField_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: TemplateName,
                                                 Model: viewModel,
                                                 Prefix: GetPrefix(field, part)));
        }

        /// <summary>
        /// Save information then show edit form
        /// </summary>
        /// <param name="part"></param>
        /// <param name="field"></param>
        /// <param name="updater"></param>
        /// <param name="shapeHelper"></param>
        /// <returns></returns>
        protected override DriverResult Editor(ContentPart part, Fields.ElapsedTimeField field, IUpdateModel updater, dynamic shapeHelper)
        {
            var viewModel = new ElapsedTimeFieldViewModel();

            if (updater.TryUpdateModel(viewModel, GetPrefix(field, part), null, null))
            {
                var settings = field.PartFieldDefinition.Settings.GetModel<ElapsedTimeFieldSettings>();
                field.ElapsedTime = string.Format("{0}:{1}, {2}:{3}, {4}:{5}, {6}:{7}, {8}:{9}",
                                                  Constants.Years, viewModel.Data.Years.ToString(),
                                                  Constants.Months, viewModel.Data.Months.ToString(),
                                                  Constants.Days, viewModel.Data.Days.ToString(),
                                                  Constants.Hours, viewModel.Data.Hours.ToString(),
                                                  Constants.Minutes, viewModel.Data.Minutes.ToString());
            }

            return Editor(part, field, shapeHelper);
        }

        protected override void Importing(ContentPart part, Fields.ElapsedTimeField field, ImportContentContext context)
        {
            var importedText = context.Attribute(GetPrefix(field, part), "ElapsedTime");
            if (importedText != null)
            {
                field.Storage.Set(null, importedText);
            }
        }

        protected override void Exporting(ContentPart part, Fields.ElapsedTimeField field, ExportContentContext context)
        {
            context.Element(GetPrefix(field, part)).SetAttributeValue("ElapsedTime", field.Storage.Get<string>(null));
        }
    }
}