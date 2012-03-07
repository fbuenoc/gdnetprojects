﻿using WebFrameworkBusiness.Base;

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
            public Comment NewInstance()
            {
                return BusinessEntityBase.Factory.NewInstance<Comment>();
            }

            public Comment Create(string title, string body)
            {
                var cm = BusinessEntityBase.Factory.Create<Comment>();
                cm.Title = title;
                cm.Body = body;

                return cm;
            }
        }
    }
}