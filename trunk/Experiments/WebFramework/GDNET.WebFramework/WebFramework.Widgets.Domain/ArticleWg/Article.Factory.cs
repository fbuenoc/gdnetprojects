using WebFramework.Domain.Common;

namespace WebFramework.Widgets.Domain.ArticleWg
{
    public partial class Article
    {
        public static ArticleFactory Factory
        {
            get { return new ArticleFactory(); }
        }

        public class ArticleFactory
        {
            public Article Create()
            {
                var article = new Article() { };

                StatutLog statutLog = StatutLog.Factory.Create(typeof(ArticleFactory).FullName);
                article.LifeCycle.AddStatutLog(statutLog);

                return article;
            }

            public Article Create(string title, string description, string fulContent)
            {
                var article = this.Create();
                article.Title = title;
                article.Description = description;
                article.FullContent = fulContent;

                return article;
            }
        }
    }
}