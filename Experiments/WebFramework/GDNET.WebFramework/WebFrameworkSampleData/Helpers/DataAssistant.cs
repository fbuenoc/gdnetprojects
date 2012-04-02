using System;
using System.Collections.Generic;
using GDNET.Common.Helpers;
using GDNET.Common.Types;
using GDNET.Extensions;
using NHibernate;
using WebFramework.Business.Administration;
using WebFramework.Business.Base;
using WebFramework.Business.Common;
using WebFramework.Business.Helpers;
using WebFramework.Common.Widgets;
using WebFramework.Data.UnitTest;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.Extensions;
using WebFramework.Domain.System;
using WebFramework.NHibernate;
using WebFramework.NHibernate.SessionManagers;
using WebFramework.Widgets.Models.Contact;
using WebFramework.Widgets.Models.DetailArticle;
using WebFramework.Widgets.Models.HtmlContent;
using WebFramework.Widgets.Models.RecentArticles;
using WebFramework.Widgets.Models.RecentProducts;
using WebFramework.Widgets.Models.RelatedItems;

namespace WebFrameworkSampleData
{
    public static class DataAssistant
    {
        public static void Initialize(ISession session)
        {
            var sessionService = new SampleDataSessionService();
            var sessionStrategy = new AppSessionStrategy(session);
            var repositories = new FrameworkRepositories(sessionStrategy);
            var services = new InfrastructureServices();
        }

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

        public static void GenerateSystemContents()
        {
            Application app = DomainRepositories.Application.GetByRootUrl("*");
            Culture culture = DomainRepositories.Culture.GetDefault();

            #region Pages

            Page homePage = Page.Factory.Create("Homepage", "welcome", app, culture);
            homePage.Description = "GiangDuong.NET - Welcome";
            homePage.Keyword = "Giang duong online, Chia se tai lieu giay";
            homePage.IsDefault = true;
            DomainRepositories.Page.Save(homePage);

            Zone homePageHeaderZone = Zone.Factory.Create("Header", string.Empty);
            Zone homePageFooterZone = Zone.Factory.Create("Footer", string.Empty);
            Zone homePageLeftContentZone = Zone.Factory.Create("LeftContent", string.Empty);
            Zone homePageRightContentZone = Zone.Factory.Create("RightContent", string.Empty);
            homePage.AddZones(homePageHeaderZone, homePageFooterZone, homePageLeftContentZone, homePageRightContentZone);
            DomainRepositories.RepositoryAssistant.Flush();

            Page aboutPage = Page.Factory.Create("About us", "about", app, culture);
            aboutPage.Description = "GiangDuong.NET - Information";
            DomainRepositories.Page.Save(aboutPage);

            Zone aboutPageHeaderZone = Zone.Factory.Create("Header", string.Empty);
            Zone aboutPageFooterZone = Zone.Factory.Create("Footer", string.Empty);
            Zone aboutPageLeftContentZone = Zone.Factory.Create("LeftContent", string.Empty);
            Zone aboutPageRightContentZone = Zone.Factory.Create("RightContent", string.Empty);
            aboutPage.AddZones(aboutPageHeaderZone, aboutPageFooterZone, aboutPageLeftContentZone, aboutPageRightContentZone);
            DomainRepositories.RepositoryAssistant.Flush();

            Page detailArticlePage = Page.Factory.Create("Detail article", "detail", app, culture);
            detailArticlePage.Description = "GiangDuong.NET - Detail article";
            DomainRepositories.Page.Save(detailArticlePage);

            Zone detailPageHeaderZone = Zone.Factory.Create("Header", string.Empty);
            Zone detailPageFooterZone = Zone.Factory.Create("Footer", string.Empty);
            Zone detailPageLeftContentZone = Zone.Factory.Create("LeftContent", string.Empty);
            Zone detailPageRightContentZone = Zone.Factory.Create("RightContent", string.Empty);
            detailArticlePage.AddZones(detailPageHeaderZone, detailPageFooterZone, detailPageLeftContentZone, detailPageRightContentZone);
            DomainRepositories.RepositoryAssistant.Flush();

            #endregion

            #region Widgets

            HtmlContentWidget htmlWidget = new HtmlContentWidget();
            htmlWidget.Install();

            ContactWidget contactWidget = new ContactWidget();
            contactWidget.Install();

            RecentProductsWidget productWidget = new RecentProductsWidget();
            productWidget.Install();

            RecentArticlesWidget articlesWidget = new RecentArticlesWidget();
            articlesWidget.Install();

            DetailArticleWidget detailArticleWidget = new DetailArticleWidget();
            detailArticleWidget.Install();

            RelatedItemsWidget relatedItemsWidget = new RelatedItemsWidget();
            relatedItemsWidget.Install();

            #endregion

            #region Widget infos

            Widget htmlWidgetInfo = DomainRepositories.Widget.GetByCode(htmlWidget.Code);
            Widget contactWidgetInfo = DomainRepositories.Widget.GetByCode(contactWidget.Code);
            Widget productWidgetInfo = DomainRepositories.Widget.GetByCode(productWidget.Code);
            Widget articlesWidgetInfo = DomainRepositories.Widget.GetByCode(articlesWidget.Code);
            Widget detailArticleWidgetInfo = DomainRepositories.Widget.GetByCode(detailArticleWidget.Code);
            Widget relatedItemsInfo = DomainRepositories.Widget.GetByCode(relatedItemsWidget.Code);

            #endregion

            #region Home page regions

            Region leftContentHPR1 = Region.Factory.Create("Who we are?", htmlWidgetInfo);
            DomainServices.Region.ApplyDefaultProperties(leftContentHPR1);
            homePageLeftContentZone.AddRegion(leftContentHPR1);

            Region leftContentHPR2 = Region.Factory.Create("Our plan", htmlWidgetInfo);
            DomainServices.Region.ApplyDefaultProperties(leftContentHPR2);
            homePageLeftContentZone.AddRegion(leftContentHPR2);

            Region leftContentHPR3 = Region.Factory.Create("Recent products", productWidgetInfo);
            DomainServices.Region.ApplyDefaultProperties(leftContentHPR3);
            homePageLeftContentZone.AddRegion(leftContentHPR3);

            Region rightContentHPR1 = Region.Factory.Create("Recent articles", articlesWidgetInfo);
            DomainServices.Region.ApplyDefaultProperties(rightContentHPR1);
            homePageRightContentZone.AddRegion(rightContentHPR1);

            #endregion

            #region About page regions

            Region aboutRegion1 = Region.Factory.Create("About us", htmlWidgetInfo);
            DomainServices.Region.ApplyDefaultProperties(aboutRegion1);
            aboutPageLeftContentZone.AddRegion(aboutRegion1);

            #endregion

            #region Detail page regions

            Region detailRegion1 = Region.Factory.Create("Detail article", detailArticleWidgetInfo);
            DomainServices.Region.ApplyDefaultProperties(detailRegion1);
            detailPageLeftContentZone.AddRegion(detailRegion1);

            Region detailRegion2 = Region.Factory.Create("Related items", relatedItemsInfo);
            DomainServices.Region.ApplyDefaultProperties(detailRegion2);
            detailPageRightContentZone.AddRegion(detailRegion2);

            #endregion

            DomainRepositories.RepositoryAssistant.Flush();

            // content from Homepage links to about page
            var connection1 = RegionConnection.Factory.Create(aboutRegion1, WidgetActions.Detail);
            leftContentHPR1.AddConnection(connection1);

            // Articles from homepage link to detail page
            var connection2 = RegionConnection.Factory.Create(detailRegion1, WidgetActions.Detail);
            rightContentHPR1.AddConnection(connection2);

            // Articles from detail page link to this page
            var connection3 = RegionConnection.Factory.Create(detailRegion1, WidgetActions.Detail);
            detailRegion2.AddConnection(connection3);

            DomainRepositories.RepositoryAssistant.Flush();
        }
    }
}
