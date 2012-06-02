using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using WebFramework.Common.Constants;
using WebFramework.Common.Controllers;
using WebFramework.Domain;
using WebFramework.Extensions;
using WebFramework.Widgets.Domain.FileWg.Repositories;
using WebFramework.Widgets.FileManagerWg.Models;

namespace WebFramework.Widgets.FileManagerWg.Controllers
{
    public class AdminController : AbstractListCrudController<FileContentModel>
    {
        private IFileContentRepository fileContentRepository = null;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            this.fileContentRepository = DomainRepositories.GetWidgetRepository<IFileContentRepository>(base.CurrentWidget);
        }

        public override ActionResult Index()
        {
            var objet = new
            {
                zid = this.HttpContext.Request.QueryString[QueryStringConstants.ZoneId],
                rid = this.HttpContext.Request.QueryString[QueryStringConstants.RegionId],
            };
            return base.RedirectToAction(ActionList, objet);
        }

        public override ActionResult List()
        {
            IList<FileContentModel> listeFiles = null;

            var region = ControllerAssistant.GetCurrentRegion();
            if (region == null)
            {
                listeFiles = this.fileContentRepository.GetAll().Select(x => new FileContentModel(x)).ToList();
            }
            else
            {
                listeFiles = this.fileContentRepository.GetAllByRegion(region).Select(x => new FileContentModel(x)).ToList();
            }

            return base.View(listeFiles);
        }

        protected override object OnCreateExecuting(FileContentModel model, FormCollection collection)
        {
            throw new System.NotImplementedException();
        }

        protected override bool OnDeleteExecuting(FileContentModel model, FormCollection collection)
        {
            return this.fileContentRepository.Delete(model.Id);
        }

        protected override bool OnEditExecuting(FileContentModel model, FormCollection collection)
        {
            throw new System.NotImplementedException();
        }
    }
}
