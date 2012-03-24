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
            public Page Create(string name)
            {
                var p = new Page()
                {
                    Name = name,
                };

                return p;
            }
        }
    }
}
