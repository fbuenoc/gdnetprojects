using System;
using System.Collections.Generic;
using GDNET.Common.Helpers;
using GDNET.Common.Types;
using GDNET.Extensions;
using WebFramework.Business.Administration;
using WebFramework.Business.Base;
using WebFramework.Business.Common;
using WebFramework.Business.Helpers;
using WebFramework.Domain;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Extensions;

namespace WebFrameworkSampleData
{
    public static partial class DataAssistant
    {
        #region Sample contents

        public static void GenerateSampleContents()
        {
            Console.WriteLine("GenerateSampleContents");

            var listeTypes = ReflectionAssistant.GetTypesImplementedInterface(typeof(IBusinessEntity));
            foreach (Type businessType in listeTypes)
            {
                if (businessType.GetHashCode() == typeof(Comment).GetHashCode())
                {
                    GenerateSampleComments();
                }
                else if (businessType.GetHashCode() == typeof(Article).GetHashCode())
                {
                    GenerateSampleArticles();
                }
                else if (businessType.GetHashCode() == typeof(Product).GetHashCode())
                {
                    GenerateSampleProducts();
                }
                else if (businessType.GetHashCode() == typeof(Shortcut).GetHashCode())
                {
                    GenerateSampleShortcuts();
                }
            }

            DomainRepositories.RepositoryAssistant.Flush();
        }

        private static void GenerateSampleComments()
        {
            int max = 20;

            for (int count = 0; count < max; count++)
            {
                string title = "Comment " + (count + 1);
                string body = "This is comment " + (count + 1);

                Comment myComment = Comment.Factory.Create(title, body);
                myComment.Email = new Email("huanhvhd@gmail.com");

                myComment.Save();
            }
        }

        private static void GenerateSampleArticles()
        {
            int max = 20;
            List<long> allArticles = new List<long>();

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
                allArticles.Add(myArticle.Id);

                Console.WriteLine("Successfully created article: " + name);
            }

            GenerateRelationArticles(allArticles);
        }

        private static void GenerateRelationArticles(List<long> allArticles)
        {
            if (allArticles.Count < 1)
            {
                return;
            }

            int totalRelations = new Random().Next(1, allArticles.Count);
            while (totalRelations > 0)
            {
                int itemIndex = new Random().Next(0, allArticles.Count);

                Article myArticle = Article.Factory.NewInstance();
                myArticle.GetById(allArticles[itemIndex]);

                if (itemIndex < allArticles.Count - 1)
                {
                    Article relationArticle = Article.Factory.NewInstance();
                    relationArticle.GetById(allArticles[itemIndex + 1]);

                    myArticle.AddRelationItem(relationArticle);
                }

                totalRelations -= 1;
            }
        }

        private static void GenerateSampleProducts()
        {
            int max = 20;

            for (int count = 0; count < max; count++)
            {
                string name = GenerateRandomName();
                string description = "This is product " + (count + 1) + ": " + name;
                decimal price = (decimal)new Random().NextDouble() * 1000;

                Product myProduct = Product.Factory.Create(name, description, price);
                myProduct.Discount = (decimal)new Random().NextDouble() * price;
                myProduct.InStock = ((count % 5) != 0);

                myProduct.Save();
            }
        }

        private static string GenerateRandomName()
        {
            string name = "09";

            while (name.Length <= 10)
            {
                var x = new Random().Next(9).ToString();
                if (!x.Equals(name[name.Length - 1].ToString()))
                {
                    name += x;
                }
            }

            return name;
        }

        public static void GenerateSampleShortcuts()
        {
            Shortcut translation = Shortcut.Factory.Create("Translation list", "Managing translations", "/Framework/Translation/List");
            translation.Save();

            int max = 10;

            for (int count = 0; count < max; count++)
            {
                string name = "Link " + (count + 1);
                string description = "This is link " + (count + 1);
                string targetUrl = "http://google.com?t=" + Guid.NewGuid().ToString();

                Shortcut myShortcut = Shortcut.Factory.Create(name, description, targetUrl);
                myShortcut.Save();
            }
        }

        #endregion

        #region Content types

        public static void InitializeContentTypes()
        {
            Console.WriteLine("InitializeContentTypes");

            var listeTypes = ReflectionAssistant.GetTypesImplementedInterface(typeof(IBusinessEntity));
            foreach (Type businessType in listeTypes)
            {
                if (businessType.GetHashCode() == typeof(Comment).GetHashCode())
                {
                    InitializeCommentContentType();
                }
                else if (businessType.GetHashCode() == typeof(Article).GetHashCode())
                {
                    InitializeArticleContentType();
                }
                else if (businessType.GetHashCode() == typeof(Product).GetHashCode())
                {
                    InitializeProductContentType();
                }
                else if (businessType.GetHashCode() == typeof(Shortcut).GetHashCode())
                {
                    InitializeShortcutContentType();
                }
            }

            DomainRepositories.RepositoryAssistant.Flush();
        }

        private static void InitializeCommentContentType()
        {
            Comment myComment = Comment.Factory.NewInstance();
            string attributeCode = string.Empty;
            ContentAttributeInfo attrInfo = null;
            List<ContentAttributeInfo> attributesInfo = new List<ContentAttributeInfo>();

            attributeCode = ExpressionAssistant.GetPropertyName(() => myComment.FullName);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 0);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myComment.Email);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 1);
            attributesInfo.Add(attrInfo);

            var contentType = BusinessEntityAssistant.EnsureContentType(myComment, attributesInfo);
            EntityAssistant.ChangeActive(contentType, true);
        }

        private static void InitializeArticleContentType()
        {
            Article myArticle = Article.Factory.NewInstance();

            string attributeCode = string.Empty;
            ContentAttributeInfo attrInfo = null;
            List<ContentAttributeInfo> attributesInfo = new List<ContentAttributeInfo>();

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.Author);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 0);
            attrInfo.IsMultilingual = true;
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.SourceInfo);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 1);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.PublishedDate);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextSimpleTextBox, 2);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myArticle.MainContent);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextHtmlEditor, 3);
            attrInfo.IsMultilingual = true;
            attributesInfo.Add(attrInfo);

            var contentType = BusinessEntityAssistant.EnsureContentType(myArticle, attributesInfo);
            EntityAssistant.ChangeActive(contentType, true);
        }

        private static void InitializeProductContentType()
        {
            Product myProduct = Product.Factory.NewInstance();

            string attributeCode = string.Empty;
            ContentAttributeInfo attrInfo = null;
            List<ContentAttributeInfo> attributesInfo = new List<ContentAttributeInfo>();

            attributeCode = ExpressionAssistant.GetPropertyName(() => myProduct.Discount);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.NumberPercentage, 0);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myProduct.IntroDate);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.DateTimeFullDateTime, 1);
            attributesInfo.Add(attrInfo);

            attributeCode = ExpressionAssistant.GetPropertyName(() => myProduct.Price);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.NumberNormalNumber, 2);
            attributesInfo.Add(attrInfo);

            var contentType = BusinessEntityAssistant.EnsureContentType(myProduct, attributesInfo);
            EntityAssistant.ChangeActive(contentType, true);
        }

        private static void InitializeShortcutContentType()
        {
            Shortcut myShortcut = Shortcut.Factory.NewInstance();

            string attributeCode = string.Empty;
            ContentAttributeInfo attrInfo = null;
            List<ContentAttributeInfo> attributesInfo = new List<ContentAttributeInfo>();

            attributeCode = ExpressionAssistant.GetPropertyName(() => myShortcut.TargetUrl);
            attrInfo = new ContentAttributeInfo(attributeCode, ListValueConstants.ContentDataTypes.TextUrl, 0);
            attributesInfo.Add(attrInfo);

            var contentType = BusinessEntityAssistant.EnsureContentType(myShortcut, attributesInfo);
            EntityAssistant.ChangeActive(contentType, true);
        }

        #endregion
    }
}
