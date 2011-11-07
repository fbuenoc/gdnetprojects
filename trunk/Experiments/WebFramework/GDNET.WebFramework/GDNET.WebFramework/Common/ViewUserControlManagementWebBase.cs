using System;
using System.Web.UI.WebControls;

using GDNET.Common.Adapters.Base;
using GDNET.Common.MVP;
using GDNET.MvpWeb;

using GDNET.Web.Adapters;
using GDNET.Web.Common;

using GNC = GDNET.Web.MultilingualControls;

namespace WebFramework.Common
{
    public abstract class ViewUserControlManagementWebBase<TPresenter, TElementId> : ViewUserControlManagementBase<TPresenter, TElementId>
    {
        protected AdapterListView adapListView;

        public override void InitializeAdapters()
        {
            this.adapListView.ListView.ItemDataBound += new EventHandler<ListViewItemEventArgs>(OnListViewItemDataBound);
            this.adapListView.ListView.ItemCommand += new EventHandler<ListViewCommandEventArgs>(OnListViewItemCommand);
        }

        protected abstract void OnListViewItemDataBound(object sender, ListViewItemEventArgs e);

        protected virtual void OnListViewItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandSource is GNC.LinkButton)
            {
                GNC.LinkButton command = e.CommandSource as GNC.LinkButton;
                switch (command.Action)
                {
                    case ActionType.Edit:
                        base.OnCommandEdit(command.CommandArgument);
                        break;

                    case ActionType.Delete:
                        break;

                    case ActionType.View:
                        base.OnCommandView(command.CommandArgument);
                        break;
                }
            }
        }
    }
}