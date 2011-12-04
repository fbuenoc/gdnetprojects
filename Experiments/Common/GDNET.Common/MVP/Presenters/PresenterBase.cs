using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDNET.Common.MVP
{
    public abstract class PresenterBase : IPresenter
    {
        #region Util properties

        protected bool IsReview
        {
            get { return (this.View.Mode == ViewMode.Review); }
        }

        #endregion

        /// <summary>
        /// Instantiate a presenter
        /// </summary>
        /// <param name="view"></param>
        /// <param name="mode"></param>
        public PresenterBase(IView view, ViewMode mode)
        {
            this.View = view;
            this.View.AttachPresenter(this);
            this.View.InitializeAdapters();
            this.ChangeMode(mode);
        }

        #region IPresenterBase<TView> Members

        /// <summary>
        /// The current view
        /// </summary>
        public IView View
        {
            get;
            private set;
        }

        #endregion

        #region IPresenter Members

        /// <summary>
        /// The presenter id
        /// </summary>
        public Guid PresenterId
        {
            get;
            private set;
        }

        /// <summary>
        /// Parameters assigned by method SetParameters
        /// </summary>
        public object Parameters
        {
            get;
            private set;
        }

        /// <summary>
        /// Determine parameter status
        /// </summary>
        public bool HasParameters
        {
            get;
            private set;
        }

        /// <summary>
        /// Assign parameter for presenter. We often call this method before perform initializing.
        /// </summary>
        /// <param name="parameters"></param>
        public virtual void SetParameters(object parameters)
        {
            this.Parameters = parameters;
            this.HasParameters = true;
        }

        /// <summary>
        /// Initializes the presenter
        /// </summary>
        public abstract void Initlialize(bool isPostBack);

        /// <summary>
        /// Change mode of current view
        /// </summary>
        /// <param name="mode"></param>
        public virtual void ChangeMode(ViewMode mode)
        {
            this.View.Mode = mode;
            this.SpecifyComponents();
        }

        /// <summary>
        /// Specify which components are available.
        /// </summary>
        public virtual void SpecifyComponents() { }

        #endregion

    }
}
