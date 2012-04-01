using WebFramework.Domain.Common;

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
            public Page Create(string name, string uniqueName, Application app, Culture culture)
            {
                var page = new Page()
                {
                    Name = name,
                    UniqueName = uniqueName,
                    Application = app,
                    Culture = culture
                };

                return page;
            }

            public Page NewInstance()
            {
                return new Page();
            }
        }
    }
}
