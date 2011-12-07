using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using WebFramework.Modeles.Base;
using WebFramework.Modeles.Framework.DomainModels;

using WebFrameworkDomain.DefaultImpl;
using WebFrameworkDomain.Common;

namespace WebFramework.Areas.Framework.Controllers
{
    public class ContentItemController : ListCrudControllerBase<ContentItemModel>
    {
        public override ActionResult List()
        {
            var listOfItems = DomainRepositories.ContentItem.GetAll().Select(x => new ContentItemModel(x));
            return base.View(listOfItems);
        }

        protected override ContentItemModel OnDetailsChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override object OnCreateExecuting(ContentItemModel model, FormCollection collection)
        {
            var ciEntity = ContentItem.Factory.Create(model.Name, model.Description, model.ContentTypeId, model.Position);
            var result = DomainRepositories.ContentItem.Save(ciEntity);
            return result ? (object)ciEntity.Id : null;
        }

        protected override ContentItemModel OnDeleteChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnDeleteExecuting(ContentItemModel model, FormCollection collection)
        {
            return DomainRepositories.ContentItem.Delete(model.Id);
        }

        protected override ContentItemModel OnEditChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected override bool OnEditExecuting(ContentItemModel model, FormCollection collection)
        {
            var ciEntity = DomainRepositories.ContentItem.GetById(model.Id);
            if (ciEntity.Name != null)
            {
                ciEntity.Name.Value = model.Name;
            }
            if (ciEntity.Description != null)
            {
                ciEntity.Description.Value = model.Description;
            }
            ciEntity.Position = model.Position;

            return DomainRepositories.ContentItem.Update(ciEntity);
        }
    }
}
