using System;
using System.Web.Mvc;

namespace WebFramework.UI.Helpers
{
    public abstract class ComponentFactoryBase
    {
        protected HtmlHelper html;

        public ComponentFactoryBase(HtmlHelper html)
        {
            this.html = html;
        }

        protected string GetWebServicePath(ServicesType service)
        {
            switch (service)
            {
                case ServicesType.SystemWidget:
                    return "~/WebServices/SystemServices.asmx/GetAvaiableWidgets";

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
