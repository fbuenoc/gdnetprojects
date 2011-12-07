using System.Web.Mvc;

namespace WebFramework.Modeles.Base
{
    public abstract class CrudControllerBase<TModel> : MvcControllerBase<TModel>
    {
        public const string ActionDetails = "Details";
        public const string ActionCreate = "Create";
        public const string ActionDelete = "Delete";
        public const string ActionEdit = "Edit";
        public const string ActionList = "List";

        protected const string ViewCreateOrUpdate = "CreateOrUpdate";

        #region Methods

        public abstract ActionResult Details(string id);

        public abstract ActionResult Create();
        /// <summary>
        /// With HttpPost action
        /// </summary>
        [HttpPost]
        public abstract ActionResult Create(TModel model, FormCollection collection);

        #region Delete Methods

        protected abstract TModel OnDeleteChecking(string id);
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

        /// <summary>
        /// With HttpPost action
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public virtual ActionResult Delete(TModel model, FormCollection collection)
        {
            if (this.OnDeleteExecuting(model, collection))
            {
                return base.RedirectToAction(ActionList);
            }
            return base.View(model);
        }

        #endregion

        protected abstract TModel OnEditChecking(string id);
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

        /// <summary>
        /// With HttpPost action
        /// </summary>
        [HttpPost]
        public virtual ActionResult Edit(TModel model, FormCollection collection)
        {
            if (this.OnEditExecuting(model, collection))
            {
                return base.RedirectToAction(ActionList);
            }

            return base.View(ViewCreateOrUpdate, model);
        }

        #endregion
    }
}
