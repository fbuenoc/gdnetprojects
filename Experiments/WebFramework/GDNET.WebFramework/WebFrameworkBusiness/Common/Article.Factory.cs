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
            public Article Create()
            {
                return new Article { };
            }

            public Article Create(string name, string description, string mainContent)
            {
                var ac = this.Create();
                ac.Name = name;
                ac.Description = description;
                ac.MainContent = mainContent;

                return ac;
            }
        }
    }
}
