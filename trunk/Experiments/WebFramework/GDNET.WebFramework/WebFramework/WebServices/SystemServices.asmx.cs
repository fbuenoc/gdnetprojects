using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using GDNET.Web.Common;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;

namespace WebFramework.WebServices
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class SystemServices : SecurelyWebServiceBase
    {
        [WebMethod(EnableSession = true)]
        public IEnumerable<SelectListItem> GetAvaiableWidgets(string text)
        {
            if (base.ValidateSecurity())
            {
                IList<Widget> listOfWidgets = null;

                if (string.IsNullOrEmpty(text))
                {
                    listOfWidgets = DomainRepositories.Widget.GetAll();
                }
                else
                {
                    listOfWidgets = DomainRepositories.Widget.FindByProperty(MetaInfos.WidgetMeta.Code, text);
                }

                return new SelectList(listOfWidgets, MetaInfos.WidgetMeta.Code, MetaInfos.WidgetMeta.TechnicalName);
            }

            throw new UnauthorizedAccessException();
        }
    }
}
