using System.Web.UI.WebControls;

using GDNET.Common.Adapters;
using GDNET.Web.Adapters;
using GNC = GDNET.Web.MultilingualControls;

using WebFrameworkPresenters.Admin.Translation;
using WebFrameworkPresenters.Admin.Translation.Views;

using WebFramework.Common;
using WebFrameworkDomainDto.Common;

namespace WebFramework.Admin.Translation.Views
{
    public partial class TranslationList : ViewUserControlManagementWebBase<PresenterTranslationList, long>, IViewTranslationList
    {
        private IAdapterHyperLink adapNewTranslation;
        private IAdapterDataPager adapPagerTranslation;

        #region IViewTranslationList Members

        public IAdapterHyperLink NewTranslation
        {
            get { return this.adapNewTranslation; }
        }

        public IAdapterListView ListTranslation
        {
            get { return base.adapListView; }
        }

        public IAdapterDataPager PagerTranslation
        {
            get { return this.adapPagerTranslation; }
        }

        #endregion

        public override void InitializeAdapters()
        {
            this.adapNewTranslation = new AdapterHyperLink(this.NT);
            this.adapPagerTranslation = new AdapterDataPager(this.PGT);

            base.detailPath = "~/Admin/Translation/Detail.aspx";
            base.adapListView = new AdapterListView(this.LV);

            base.InitializeAdapters();
        }

        protected override void OnListViewItemDataBound(object sender, ListViewItemEventArgs e)
        {
            TranslationDTO dto = (TranslationDTO)e.Item.DataItem;

            GNC.Literal LC = e.Item.FindControl("LC") as GNC.Literal;
            GNC.Literal LT = e.Item.FindControl("LT") as GNC.Literal;
            GNC.LinkButton AE = e.Item.FindControl("AE") as GNC.LinkButton;
            GNC.LinkButton AD = e.Item.FindControl("AD") as GNC.LinkButton;

            LC.Text = dto.Code;
            LT.Text = dto.Text;
            AE.CommandArgument = dto.Id.ToString();
            AD.CommandArgument = dto.Id.ToString();
        }
    }
}