using WebFrameworkBusiness.Base;

namespace WebFrameworkBusiness.Common
{
    public sealed partial class Article
    {
        public static ArticleFactory Factory
        {
            get { return new ArticleFactory { }; }
        }

        public class ArticleFactory
        {
            /// <summary>
            /// Create a new instance without initializing data item (ONLY USE TO LOAD OBJECT)
            /// </summary>
            public Article NewInstance()
            {
                return BusinessEntityBase.Factory.NewInstance<Article>();
            }

            public Article Create()
            {
                return BusinessEntityBase.Factory.Create<Article>();
            }

            public Article Create(string name, string description, string mainContent)
            {
                var article = BusinessEntityBase.Factory.Create<Article>();
                article.MainContent = mainContent;

                return article;
            }

            public Article Create(string name, string description, string mainContent, int position)
            {
                var article = this.Create(name, description, mainContent);
                article.ItemData.Position = position;

                return article;
            }
        }
    }
}
