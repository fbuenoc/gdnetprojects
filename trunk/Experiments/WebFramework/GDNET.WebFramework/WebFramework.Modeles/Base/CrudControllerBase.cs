using System.Web.Mvc;

using GDNET.Web.Mvc.Base;

namespace WebFramework.Modeles.Base
{
    public abstract class CrudControllerBase<TModel> : MvcControllerBase where TModel : ModelBase
    {
        public const string ActionDetails = "Details";
        public const string ActionCreate = "Create";
        public const string ActionDelete = "Delete";
        public const string ActionEdit = "Edit";

        protected const string ViewCreateOrUpdate = "CreateOrUpdate";

        #region Methods

        public abstract ActionResult Details();

        public abstract ActionResult Create();
        /// <summary>
        /// With HttpPost action
        /// </summary>
        [HttpPost]
        public abstract ActionResult Create(TModel model, FormCollection collection);


        public abstract ActionResult Delete();
        /// <summary>
        /// With HttpPost action
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public abstract ActionResult Delete(TModel model, FormCollection collection);

        public abstract ActionResult Edit(string id);
        /// <summary>
        /// With HttpPost action
        /// </summary>
        [HttpPost]
        public abstract ActionResult Edit(TModel model, FormCollection collection);

        #endregion
    }
}
