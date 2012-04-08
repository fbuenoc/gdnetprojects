using System;
using System.Web.Mvc;

namespace WebFramework.Common.Controllers
{
    public abstract class AbstractCrudController<TModel> : AbstractController<TModel>
    {
        public const string ActionDetails = "Details";
        public const string ActionCreate = "Create";
        public const string ActionDelete = "Delete";
        public const string ActionEdit = "Edit";
        public const string ActionList = "List";

        protected const string ViewCreateOrUpdate = "CreateOrUpdate";

        #region Methods

        #region Details Methods

        protected virtual TModel OnDetailsChecking(string id)
        {
            return base.GetModelById(id);
        }

        public virtual ActionResult Details(string id)
        {
            TModel modele = this.OnDetailsChecking(id);
            if ((modele != null) && !modele.Equals(default(TModel)))
            {
                return base.View(modele);
            }

            return base.RedirectToAction(ActionList);
        }

        #endregion

        #region Create Methods

        protected virtual TModel OnCreateChecking()
        {
            return (TModel)Activator.CreateInstance(typeof(TModel));
        }

        /// <summary>
        /// Returns Id of object when succeed or NULL when failed
        /// </summary>
        protected abstract object OnCreateExecuting(TModel model, FormCollection collection);

        public virtual ActionResult Create()
        {
            TModel model = this.OnCreateChecking();
            if (model == null || model.Equals(default(TModel)))
            {
                return base.RedirectToAction(ActionList);
            }

            return base.View(ViewCreateOrUpdate, model);
        }

        [HttpPost]
        public virtual ActionResult Create(TModel model, FormCollection collection)
        {
            if (base.ModelState.IsValid)
            {
                var objectId = this.OnCreateExecuting(model, collection);
                if (objectId != null)
                {
                    return this.AfterCreated(objectId);
                }
            }

            return base.View(ViewCreateOrUpdate, model);
        }

        protected virtual ActionResult AfterCreated(object objectId)
        {
            return base.RedirectToAction(ActionDetails, new { id = objectId.ToString() });
        }

        #endregion

        #region Delete Methods

        protected virtual TModel OnDeleteChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected abstract bool OnDeleteExecuting(TModel model, FormCollection collection);

        public virtual ActionResult Delete(string id)
        {
            TModel modele = this.OnDeleteChecking(id);
            if (modele != null && !modele.Equals(default(TModel)))
            {
                return base.View(modele);
            }

            return base.RedirectToAction(ActionList);
        }

        [HttpPost]
        public virtual ActionResult Delete(TModel model, FormCollection collection)
        {
            if (this.OnDeleteExecuting(model, collection))
            {
                return this.AfterDeleted();
            }

            return base.View(model);
        }

        public virtual ActionResult AfterDeleted()
        {
            return base.RedirectToAction(ActionList);
        }

        #endregion

        protected virtual TModel OnEditChecking(string id)
        {
            return base.GetModelById(id);
        }

        protected abstract bool OnEditExecuting(TModel model, FormCollection collection);

        public virtual ActionResult Edit(string id)
        {
            TModel model = this.OnEditChecking(id);
            if ((model != null) && !model.Equals(default(TModel)))
            {
                return base.View(ViewCreateOrUpdate, model);
            }

            return base.RedirectToAction(ActionList);
        }

        [HttpPost]
        public ActionResult Edit(TModel model, FormCollection collection)
        {
            if (this.OnEditExecuting(model, collection))
            {
                return this.AfterEdited(model, collection);
            }

            return base.View(ViewCreateOrUpdate, model);
        }

        protected virtual ActionResult AfterEdited(TModel model, FormCollection collection)
        {
            return base.RedirectToAction(ActionList);
        }

        #endregion
    }
}
