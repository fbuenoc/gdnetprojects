using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GDNET.Common.MVP;
using GDNET.Common.Adapters;

namespace GDNET.Common.MVP
{
    /// <summary>
    /// Don't make you view inherite from this view directly, it should be IView<TPresenter>
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// The View ID
        /// </summary>
        Guid ViewId { get; }

        /// <summary>
        /// The ID of element attached to view
        /// </summary>
        object ElementId
        {
            get;
            set;
        }

        /// <summary>
        /// The attached Presenter
        /// </summary>
        IPresenter Presenter { get; }

        /// <summary>
        /// Current mode of the view
        /// </summary>
        ViewMode Mode { get; set; }

        /// <summary>
        /// Handles error
        /// </summary>
        /// <param name="ex"></param>
        void HandleError(Exception ex);

        /// <summary>
        /// Attach presenter into current view
        /// </summary>
        /// <param name="presenter"></param>
        void AttachPresenter(IPresenter presenter);

        /// <summary>
        /// Init all adapters used in view
        /// </summary>
        void InitializeAdapters();
    }

}
