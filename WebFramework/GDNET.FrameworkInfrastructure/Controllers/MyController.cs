using System.Web.Mvc;
using GDNET.FrameworkInfrastructure.Controllers.Base;
using GDNET.FrameworkInfrastructure.Models.My;
using GDNET.FrameworkInfrastructure.Models.System;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    public class MyController : AbstractController
    {
        public ActionResult ChangeLanguage()
        {
            ChangeLanguageModel model = new ChangeLanguageModel();
            model.UserCustomizedInformation = WebFrameworkServices.DataStored.GetUserCustomizedInfo();
            model.PageMeta.Keywords = "";
            model.PageMeta.Description = "";
            model.PageMeta.Author = "";

            return base.View(model);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(ChangeLanguageModel model)
        {
            if (base.ModelState.IsValid)
            {
                UserCustomizedInformationModel customizedModel = new UserCustomizedInformationModel(model.UserCustomizedInformation.Language, model.UserCustomizedInformation.ApplyForUI);
                WebFrameworkServices.DataStored.SetUserCustomizedInfo(customizedModel);

                return base.RedirectToAction("Index", "Home", new { language = model.UserCustomizedInformation.Language });
            }

            return base.View(model);
        }
    }
}
