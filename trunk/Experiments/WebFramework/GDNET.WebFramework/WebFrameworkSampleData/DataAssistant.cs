using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GDNET.Common.Helpers;
using GDNET.Common.Types;
using GDNET.Extensions;
using NHibernate;
using WebFrameworkBusiness.Base;
using WebFrameworkBusiness.Common;
using WebFrameworkData.UnitTest;
using WebFrameworkDomain.Common;
using WebFrameworkDomain.Constants;
using WebFrameworkDomain.DefaultImpl;
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
                var contentType = ContentType.Factory.Create(businessType.Name, businessType.GetQualifiedTypeName(), businessType.GetHashCode().ToString());
                DomainRepositories.ContentType.Save(contentType);

                if (businessType.GetHashCode() == typeof(Comment).GetHashCode())
                {
                    InitializeComment(contentType);
                    DomainRepositories.RepositoryAssistant.Flush();
                }
                else if (businessType.GetHashCode() == typeof(Article).GetHashCode())
                {
                    InitializeArticle(contentType);
                    GenerateSampleArticles();
                    DomainRepositories.RepositoryAssistant.Flush();
                }
            }
        }

        public static void InitializeComment(ContentType contentType)
        {
            Comment comment = Comment.Factory.Create();

            string attributeCode = string.Empty;
            ListValue listValue = null;
            List<ContentAttribute> listeAttributes = new List<ContentAttribute>();

            attributeCode = DataAssistant.GetContentAttributeCode(() => comment.Title);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var title = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 1);
            listeAttributes.Add(title);

            attributeCode = DataAssistant.GetContentAttributeCode(() => comment.Body);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextTextArea);
            var body = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 2);
            listeAttributes.Add(body);

            attributeCode = DataAssistant.GetContentAttributeCode(() => comment.FullName);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var fullName = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 3);
            listeAttributes.Add(fullName);

            attributeCode = DataAssistant.GetContentAttributeCode(() => comment.Email);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var email = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 4);
            listeAttributes.Add(email);

            contentType.AddContentAttributes(listeAttributes);

            DomainRepositories.ContentType.Update(contentType);
        }

        private static void GenerateSampleComments()
        {
        }

        public static void InitializeArticle(ContentType contentType)
        {
            Article art = Article.Factory.Create();

            string attributeCode = string.Empty;
            ListValue listValue = null;
            List<ContentAttribute> listeAttributes = new List<ContentAttribute>();

            attributeCode = DataAssistant.GetContentAttributeCode(() => art.Author);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var author = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 1);
            listeAttributes.Add(author);

            attributeCode = DataAssistant.GetContentAttributeCode(() => art.SourceInfo);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var sourceInfo = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 2);
            listeAttributes.Add(sourceInfo);

            attributeCode = DataAssistant.GetContentAttributeCode(() => art.PublishedDate);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextSimpleTextBox);
            var publishedDate = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 3);
            listeAttributes.Add(publishedDate);

            attributeCode = DataAssistant.GetContentAttributeCode(() => art.MainContent);
            listValue = DataRepositories.ListValue.FindByName(ListValueConstants.ContentDataTypes.TextHtmlEditor);
            var mainContent = ContentAttribute.Factory.Create(attributeCode, contentType, listValue, 4);
            listeAttributes.Add(mainContent);

            contentType.AddContentAttributes(listeAttributes);

            DomainRepositories.ContentType.Update(contentType);
        }

        private static void GenerateSampleArticles()
        {
            int max = 1;
            for (int count = 0; count < max; count++)
            {
                string name = "Article " + (count + 1);
                string description = "This is article " + (count + 1);
                string mainContent = "Main <b>content</b> of <u>article</u> " + (count + 1);
                Article myArticle = Article.Factory.Create(name, description, mainContent);

                Contact author = new Contact();
                author.ContactName = new Name();
                author.ContactName.DisplayName = "Web Framework";
                author.AddEmail(new Email("webframework", "gmail.com"));
                myArticle.Author = author;

                myArticle.Save();
            }
        }

        private static string GetContentAttributeCode<T>(Expression<Func<T>> propertyExpression)
        {
            return ExpressionAssistant.GetTypeFullName<T>(propertyExpression) + "." + ExpressionAssistant.GetPropertyName(propertyExpression);
        }
    }
}
