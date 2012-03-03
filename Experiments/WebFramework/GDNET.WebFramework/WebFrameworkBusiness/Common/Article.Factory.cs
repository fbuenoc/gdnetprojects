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

            public Article Create(string name, string description, string mainContent)
            {
                return this.Create(name, description, mainContent, int.MinValue);
            }

            public Article Create(string name, string description, string mainContent, int position)
            {
                var article = BusinessEntityBase.Factory.Create<Article>(name, description);
                article.MainContent = mainContent;
                article.Position = position;

                return article;
            }
        }
    }
}
