using WebFramework.Business.Base;

namespace WebFramework.Business.Common
{
    public sealed partial class Comment
    {
        public static CommentFactory Factory
        {
            get { return new CommentFactory(); }
        }

        public class CommentFactory
        {
            public Comment NewInstance()
            {
                return BusinessEntityBase.Factory.NewInstance<Comment>();
            }

            public Comment Create(string title, string body)
            {
                var cm = BusinessEntityBase.Factory.Create<Comment>();
                cm.Name = title;
                cm.Description = body;

                return cm;
            }
        }
    }
}
