namespace WebFramework.Domain.System
{
    public partial class Page
    {
        public static PageFactory Factory
        {
            get { return new PageFactory(); }
        }

        public class PageFactory
        {
            public Page Create(string name, string uniqueName)
            {
                var page = new Page()
                {
                    Name = name,
                    UniqueName = uniqueName,
                };

                return page;
            }
        }
    }
}
