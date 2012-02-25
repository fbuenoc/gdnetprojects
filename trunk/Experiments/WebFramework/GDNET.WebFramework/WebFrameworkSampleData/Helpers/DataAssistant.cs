using System;
using System.Collections.Generic;
using GDNET.Common.Helpers;
using GDNET.Common.Types;
using GDNET.Extensions;
using NHibernate;
using WebFrameworkBusiness.Base;
using WebFrameworkBusiness.Common;
using WebFrameworkBusiness.Helpers;
using WebFrameworkData.UnitTest;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;
using WebFrameworkDomain.Extensions;
using WebFrameworkNHibernate;
using WebFrameworkNHibernate.SessionManagers;

namespace WebFrameworkSampleData
{
    public static class DataAssistant
    {
        public static void Initialize(ISession session)
        {
            var sessionService = new SampleDataSessionService();
            var sessionStrategy = new AppSessionStrategy(session);
            var repositories = new DataRepositories(sessionStrategy);
        }

        public static void GenerateContentTypes()
        {
            var listeTypes = ReflectionAssistant.GetTypesImplementedInterface(typeof(IBusinessEntity));
            foreach (Type businessType in listeTypes)
            {
                if (businessType.GetHashCode() == typeof(Comment).GetHashCode())
                {
                    InitializeComment();
                    DomainRepositories.RepositoryAssistant.Flush();
                }
                else if (businessType.GetHashCode() == typeof(Article).GetHashCode())
                {
                    InitializeArticle();
                    GenerateSampleArticles();
                    DomainRepositories.RepositoryAssistant.Flush();
                }
            }
        }

        public static void InitializeComment()
        {
            Comment myComment = Comment.Factory.NewInstance();
            string attributeCode = string.Empty;
            ContentAttributeInfo attrInfo = null;
            List<ContentAttributeInfo> attributesInfo = new List<ContentAttributeInfo>();

            attributeCode = ExpressionAssistant.GetPropertyName(() => myComment.Title);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 0);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myComment.Body);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextTextArea, 1);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myComment.FullName);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 2);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myComment.Email);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 3);
            attributesInfo.Add(attrInfo);

            var contentType = BusinessEntityAssistant.EnsureContentType(myComment, attributesInfo);
            EntityAssistant.ChangeActive(contentType, true);
        }

        private static void GenerateSampleComments()
        {
        }

        public static void InitializeArticle()
        {
            Article myArticle = Article.Factory.NewInstance();

            string attributeCode = string.Empty;
            ContentAttributeInfo attrInfo = null;
            List<ContentAttributeInfo> attributesInfo = new List<ContentAttributeInfo>();

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.Author);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 0);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.SourceInfo);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 1);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.PublishedDate);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 2);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.MainContent);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextHtmlEditor, 3);
            attributesInfo.Add(attrInfo);

            var contentType = BusinessEntityAssistant.EnsureContentType(myArticle, attributesInfo);
            EntityAssistant.ChangeActive(contentType, true);
        }

        private static void GenerateSampleArticles()
        {
            int max = 10;

            for (int count = 0; count < max; count++)
            {
                string name = "Article " + (count + 1);
                string description = "This is article " + (count + 1);
                string mainContent = "Main <b>content</b> of <u>article</u> " + (count + 1);
                Article myArticle = Article.Factory.Create(name, description, mainContent);

                Contact author = new Contact();
                author.ContactName = new Name();
                author.ContactName.DisplayName = "Web Framework";
                author.AddEmail(new Email("webframework@gmail.com"));
                myArticle.Author = author;

                int activeFlag = new Random().Next(0, 1);
                EntityAssistant.ChangeActive(myArticle, (activeFlag == 1));

                myArticle.Save();

                Console.WriteLine("Successfully created article: " + name);
            }
        }
    }
}
