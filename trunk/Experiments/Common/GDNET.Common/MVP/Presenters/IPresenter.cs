using System;

using GDNET.Common.MVP;

namespace GDNET.Common.MVP
{
    public interface IPresenter
    {
        /// <summary>
        /// The presenter id
        /// </summary>
        Guid PresenterId { get; }

        /// <summary>
        /// The current view
        /// </summary>
        IView View { get; }

        /// <summary>
        /// Parameters assigned by method SetParameters
        /// </summary>
        object Parameters { get; }

        /// <summary>
        /// Determine parameter status
        /// </summary>
        bool HasParameters { get; }

        /// <summary>
        /// Assign parameter for presenter. We often call this method before perform initializing.
        /// </summary>
        /// <param name="parameter"></param>
        void SetParameters(object parameters);

        /// <summary>
        /// Initializes the presenter
        /// </summary>
        void Initlialize(bool isPostBack);

        /// <summary>
        /// Change mode of current view
        /// </summary>
        /// <param name="mode"></param>
        void ChangeMode(ViewMode mode);

        /// <summary>
        /// Specify which components are available.
        /// </summary>
        void SpecifyComponents();
    }

}
