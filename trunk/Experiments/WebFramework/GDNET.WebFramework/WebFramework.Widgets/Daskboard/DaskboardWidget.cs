using System.Web.Mvc;
using WebFramework.Common.Widgets;

namespace WebFramework.Widgets.Daskboard
{
    public class DaskboardWidget : WidgetBase<DaskboardWidgetModel>
    {
        public override string Code
        {
            get { return "E5B8B2D6-6CDE-4D63-A750-2416B20C8D84"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                string.Format("{0}_Default", this.AreaName),
                string.Format("{0}/{{controller}}/{{action}}/{{id}}", this.TechnicalName),
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { string.Format("{0}.Controllers", this.GetType().Namespace) }
            );
        }

        protected override DaskboardWidgetModel InitializeModel()
        {
            DaskboardWidgetModel modelResult = new DaskboardWidgetModel(base.regionModel);
            return modelResult;
        }
    }
}