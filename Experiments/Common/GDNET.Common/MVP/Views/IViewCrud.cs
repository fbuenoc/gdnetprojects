using GDNET.Common.Adapters;

namespace GDNET.Common.MVP
{
    public interface IViewCrud : IView
    {
        IViewNotification Notifier { get; }

        IAdapterLinkButton ActionReturn { get; }
        IAdapterLinkButton ActionEdit { get; }

        IAdapterButton ActionReset { get; }
        IAdapterButton ActionSubmit { get; }
        IAdapterButton ActionDelete { get; }

        bool HasElementId { get; }

        void ExecuteReturn();
    }
}
