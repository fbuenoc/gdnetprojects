using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.DesignByContract;

namespace GDNET.Common.MVP
{
    public abstract class PresenterCrudBase : PresenterBase
    {
        #region Util properties

        protected bool IsCreatationOrModification
        {
            get { return (this.View.Mode == ViewMode.Modification || this.View.Mode == ViewMode.Creation); }
        }

        protected bool IsDeletion
        {
            get { return (this.View.Mode == ViewMode.Deletion); }
        }

        protected bool IsCreation
        {
            get { return (this.View.Mode == ViewMode.Creation); }
        }

        protected bool IsModification
        {
            get { return (this.View.Mode == ViewMode.Modification); }
        }

        #endregion

        protected new IViewCrud View
        {
            get { return (IViewCrud)base.View; }
        }

        public PresenterCrudBase(IViewCrud view, ViewMode mode)
            : base(view, mode)
        {
            this.View.ActionDelete.Click += new EventHandler(OnActionDelete);
            this.View.ActionReturn.Click += new EventHandler(OnActionReturn);
            this.View.ActionEdit.Click += new EventHandler(OnActionEdit);
            this.View.ActionSubmit.Click += new EventHandler(OnActionSubmit);
        }

        #region Events

        /// <summary>
        /// Perform an action to database (Creatation or Modification)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnActionSubmit(object sender, EventArgs e)
        {
            bool result = false;
            this.View.Notifier.Visible = false;

            try
            {
                switch (this.View.Mode)
                {
                    case ViewMode.Creation:
                        result = this.Create();
                        break;

                    case ViewMode.Modification:
                        result = this.Modify();
                        break;

                    case ViewMode.Deletion:
                        result = this.Delete();
                        break;

                    default:
                        if (this.View.Mode != ViewMode.None)
                        {
                            Throw.NotImplementedException(string.Format("The mode: {0} is not handled.", this.View.Mode.ToString()));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                this.NotifyError(ex);
            }

            if (result)
            {
                switch (this.View.Mode)
                {
                    case ViewMode.Creation:
                    case ViewMode.Modification:
                        this.ChangeMode(ViewMode.Review);
                        break;

                    case ViewMode.Deletion:
                        this.View.ExecuteReturn();
                        break;
                }
            }
        }

        /// <summary>
        /// Switch to Edit mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnActionEdit(object sender, EventArgs e)
        {
            this.ChangeMode(ViewMode.Modification);
        }

        /// <summary>
        /// Return to management page (often a list page)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnActionReturn(object sender, EventArgs e)
        {
            this.View.ExecuteReturn();
        }

        /// <summary>
        /// Perform a deletion action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnActionDelete(object sender, EventArgs e)
        {
            base.ChangeMode(ViewMode.Deletion);
        }

        #endregion

        public virtual bool Create()
        {
            Throw.NotImplementedException("Not implemented");
            return false;
        }

        public virtual bool Delete()
        {
            Throw.NotImplementedException("Not implemented");
            return false;
        }

        public virtual bool Modify()
        {
            Throw.NotImplementedException("Not implemented");
            return false;
        }

        public virtual bool Review()
        {
            Throw.NotImplementedException("Not implemented");
            return false;
        }

        protected virtual void NotifyError(Exception ex)
        {
            this.View.Notifier.Visible = true;
            this.View.Notifier.IsError = true;
            this.View.Notifier.Message = ex.Message;
        }

        /// <summary>
        /// Specify which components are available.
        /// </summary>
        public override void SpecifyComponents()
        {
            switch (this.View.Mode)
            {
                case ViewMode.Review:
                    {
                        this.View.ActionReset.Visible = false;
                        this.View.ActionSubmit.Visible = false;

                        this.View.ActionDelete.Visible = true;
                        this.View.ActionEdit.Visible = true;
                        this.View.ActionReturn.Visible = true;
                    }
                    break;

                case ViewMode.Creation:
                case ViewMode.Modification:
                    {
                        this.View.ActionReset.Visible = true;
                        this.View.ActionSubmit.Visible = true;

                        this.View.ActionDelete.Visible = false;
                        this.View.ActionEdit.Visible = false;
                        this.View.ActionReturn.Visible = true;
                    }
                    break;

                case ViewMode.Deletion:
                    {
                        this.View.ActionReset.Visible = false;
                        this.View.ActionSubmit.Visible = true;

                        this.View.ActionDelete.Visible = false;
                        this.View.ActionEdit.Visible = false;
                        this.View.ActionReturn.Visible = true;
                    }
                    break;
            }
        }

    }
}
