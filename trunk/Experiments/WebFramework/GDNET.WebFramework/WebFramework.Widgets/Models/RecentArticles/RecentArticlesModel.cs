using System;
using System.Collections.Generic;
using System.Linq;
using GDNET.Extensions;
using WebFramework.Common.Framework.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Domain.Common;

namespace WebFramework.Widgets.Models.RecentArticles
{
    public sealed class RecentArticlesModel : WidgetModelBase
    {
        #region Ctors

        public RecentArticlesModel(RegionModel regionModel)
            : base(regionModel)
        {
        }

        #endregion

        #region Properties

        public IList<ContentItemModel> Articles
        {
            get;
            private set;
        }

        public ViewOption ViewOption
        {
            get { return this.GetPropertyValue<ViewOption>(RecentArticlesConstants.ViewOption); }
        }

        #endregion

        #region Methods

        protected override T GetPropertyValue<T>(string propertyName)
        {
            if (propertyName == RecentArticlesConstants.ViewOption)
            {
                string propertyValue = base.GetPropertyValue<string>(propertyName);
                object result = EnumAssistant.ParseEnum<ViewOption>(propertyValue);
                return (T)Convert.ChangeType(result, typeof(T));
            }

            return base.GetPropertyValue<T>(propertyName);
        }

        public void InitializeArticles(IList<ContentItem> articles)
        {
            this.Articles = articles.Select(x => new ContentItemModel(x)).ToList();
        }

        #endregion
    }
}