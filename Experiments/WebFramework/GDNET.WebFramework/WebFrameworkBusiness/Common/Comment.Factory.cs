namespace WebFrameworkBusiness.Common
{
    public sealed partial class Comment
    {
        public static CommentFactory Factory
        {
            get { return new CommentFactory(); }
        }

        public class CommentFactory
        {
            public Comment Create()
            {
                return new Comment { };
            }

            public Comment Create(string title, string body)
            {
                var cm = this.Create();
                cm.Title = title;
                cm.Body = body;

                return cm;
            }
        }
    }
}
