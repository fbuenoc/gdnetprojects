using System.Web.Mvc;
using GDNET.AOP.ExceptionHandling;
using GDNET.FrameworkInfrastructure.Controllers.Base;
using GDNET.FrameworkInfrastructure.Controllers.Extensions;
using GDNET.FrameworkInfrastructure.Models.PageModels;
using GDNET.FrameworkInfrastructure.Models.System;
using GDNET.FrameworkInfrastructure.Services;

namespace GDNET.FrameworkInfrastructure.Controllers
{
    [CaptureException]
    public class MyController : AbstractController
    {
        public ActionResult ChangeLanguage()
        {
            MyChangeLanguageModel model = new MyChangeLanguageModel();
            model.UserCustomizedInformation = InfrastructureServices.DataStored.GetUserCustomizedInfo();
            model.PageMeta.Keywords = "";
            model.PageMeta.Description = "";
            model.PageMeta.Author = "";

            return base.View(model);
        }

        [HttpPost]
        public ActionResult ChangeLanguage(MyChangeLanguageModel model)
        {
            if (base.ModelState.IsValid)
            {
                UserCustomizedInformationModel customizedModel = new UserCustomizedInformationModel(model.UserCustomizedInformation.Language, model.UserCustomizedInformation.LanguageUI);
                InfrastructureServices.DataStored.SetUserCustomizedInfo(customizedModel);

                return base.RedirectToAction("Index", ListControllers.Home, new { language = model.UserCustomizedInformation.LanguageUI });
            }

            return base.View(model);
        }
    }
}
