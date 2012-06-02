﻿using System;
using GDNET.Common.Security.Services;
using NHibernate;
using WebFramework.Common.Widgets;
using WebFramework.Data.UnitTest;
using WebFramework.Domain;
using WebFramework.Domain.Common;
using WebFramework.Domain.Constants;
using WebFramework.Domain.System;
using WebFramework.NHibernate;
using WebFramework.NHibernate.SessionManagers;
using WebFramework.Widgets.ArticleWg;
using WebFramework.Widgets.Domain.ArticleWg;
using WebFramework.Widgets.Domain.ArticleWg.Repositories;
using WebFramework.Widgets.Domain.FileWg;
using WebFramework.Widgets.Domain.FileWg.Repositories;
using WebFramework.Widgets.FileManagerWg;
using WebFramework.Widgets.HtmlContentWg;
using WebFramework.Widgets.Models.Contact;
using WebFramework.Widgets.Models.RecentArticles;
using WebFramework.Widgets.Models.RecentProducts;
using WebFramework.Widgets.Models.RelatedItems;

namespace WebFrameworkSampleData
{
    public static partial class DataAssistant
    {
        public static void Initialize(ISession session)
        {
            var sessionService = new SampleDataSessionService();
            var sessionStrategy = new AppSessionStrategy(session);
            var repositories = new FrameworkRepositories(sessionStrategy);
            var services = new InfrastructureServices();
        }

        public static void GenerateSystemContents()
        {
            Application app = DomainRepositories.Application.GetByRootUrl("*");
            Culture culture = DomainRepositories.Culture.GetDefault();

            #region Pages

            Page homePage = Page.Factory.Create("Homepage", "welcome", app, culture);
            homePage.Description = "GiangDuong.NET - Welcome";
            homePage.Keyword = "Giang duong online, Chia se tai lieu giay";
            homePage.IsDefault = true;
            homePage.IsActive = true;
            DomainRepositories.Page.Save(homePage);

            Zone homePageHeaderZone = Zone.Factory.Create("Header", string.Empty);
            homePageHeaderZone.IsActive = true;
            Zone homePageFooterZone = Zone.Factory.Create("Footer", string.Empty);
            homePageFooterZone.IsActive = true;
            Zone homePageLeftContentZone = Zone.Factory.Create("LeftContent", string.Empty);
            homePageLeftContentZone.IsActive = true;
            Zone homePageRightContentZone = Zone.Factory.Create("RightContent", string.Empty);
            homePageRightContentZone.IsActive = true;
            homePage.AddZones(homePageHeaderZone, homePageFooterZone, homePageLeftContentZone, homePageRightContentZone);
            DomainRepositories.RepositoryAssistant.Flush();

            Page aboutPage = Page.Factory.Create("About us", "about", app, culture);
            aboutPage.Description = "GiangDuong.NET - Information";
            aboutPage.IsActive = true;
            DomainRepositories.Page.Save(aboutPage);

            Zone aboutPageHeaderZone = Zone.Factory.Create("Header", string.Empty);
            Zone aboutPageFooterZone = Zone.Factory.Create("Footer", string.Empty);
            Zone aboutPageLeftContentZone = Zone.Factory.Create("LeftContent", string.Empty);
            Zone aboutPageRightContentZone = Zone.Factory.Create("RightContent", string.Empty);
            aboutPage.AddZones(aboutPageHeaderZone, aboutPageFooterZone, aboutPageLeftContentZone, aboutPageRightContentZone);
            DomainRepositories.RepositoryAssistant.Flush();

            Page detailArticlePage = Page.Factory.Create("Detail article", "detail", app, culture);
            detailArticlePage.Description = "GiangDuong.NET - Detail article";
            detailArticlePage.IsActive = true;
            DomainRepositories.Page.Save(detailArticlePage);

            Zone detailPageHeaderZone = Zone.Factory.Create("Header", string.Empty);
            detailPageHeaderZone.IsActive = true;
            Zone detailPageFooterZone = Zone.Factory.Create("Footer", string.Empty);
            detailPageFooterZone.IsActive = true;
            Zone detailPageLeftContentZone = Zone.Factory.Create("LeftContent", string.Empty);
            detailPageLeftContentZone.IsActive = true;
            Zone detailPageRightContentZone = Zone.Factory.Create("RightContent", string.Empty);
            detailPageRightContentZone.IsActive = true;
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

            RelatedItemsWidget relatedItemsWidget = new RelatedItemsWidget();
            relatedItemsWidget.Install();

            ArticleWidget articleWidget = new ArticleWidget();
            articleWidget.Install();

            FileManagerWidget fileManager = new FileManagerWidget();
            fileManager.Install();

            #endregion

            #region Widget infos

            Widget htmlWidgetInfo = DomainRepositories.Widget.GetByCode(htmlWidget.Code);
            Widget contactWidgetInfo = DomainRepositories.Widget.GetByCode(contactWidget.Code);
            Widget productWidgetInfo = DomainRepositories.Widget.GetByCode(productWidget.Code);
            Widget articlesWidgetInfo = DomainRepositories.Widget.GetByCode(articlesWidget.Code);
            Widget relatedItemsInfo = DomainRepositories.Widget.GetByCode(relatedItemsWidget.Code);
            Widget articleWidgetInfo = DomainRepositories.Widget.GetByCode(articleWidget.Code);
            Widget fileManagerWidgetInfo = DomainRepositories.Widget.GetByCode(fileManager.Code);

            #endregion

            #region Home page regions

            Region leftR1 = Region.Factory.Create("Some articles", articleWidgetInfo);
            leftR1.IsActive = true;
            DomainServices.Region.ApplyDefaultProperties(leftR1);
            homePageLeftContentZone.AddRegion(leftR1);
            GenerateDemoDataArticles(leftR1, articleWidgetInfo);

            Region leftContentHPR1 = Region.Factory.Create("Who we are?", htmlWidgetInfo);
            leftContentHPR1.IsActive = true;
            DomainServices.Region.ApplyDefaultProperties(leftContentHPR1);
            homePageLeftContentZone.AddRegion(leftContentHPR1);

            Region leftContentHPR2 = Region.Factory.Create("Some files", fileManagerWidgetInfo);
            leftContentHPR2.IsActive = true;
            DomainServices.Region.ApplyDefaultProperties(leftContentHPR2);
            homePageLeftContentZone.AddRegion(leftContentHPR2);
            GenerateDemoDataFileContents(leftContentHPR2, fileManagerWidgetInfo);

            //Region leftContentHPR3 = Region.Factory.Create("Recent products", productWidgetInfo);
            //leftContentHPR3.IsActive = true;
            //DomainServices.Region.ApplyDefaultProperties(leftContentHPR3);
            //homePageLeftContentZone.AddRegion(leftContentHPR3);

            //Region rightContentHPR1 = Region.Factory.Create("Recent articles", articlesWidgetInfo);
            //rightContentHPR1.IsActive = true;
            //DomainServices.Region.ApplyDefaultProperties(rightContentHPR1);
            //homePageRightContentZone.AddRegion(rightContentHPR1);

            #endregion

            #region About page regions

            Region aboutRegion1 = Region.Factory.Create("About us", htmlWidgetInfo);
            aboutRegion1.IsActive = true;
            DomainServices.Region.ApplyDefaultProperties(aboutRegion1);
            aboutPageLeftContentZone.AddRegion(aboutRegion1);

            #endregion

            #region Detail page regions

            Region detailRegion2 = Region.Factory.Create("Related items", relatedItemsInfo);
            detailRegion2.IsActive = true;
            DomainServices.Region.ApplyDefaultProperties(detailRegion2);
            detailPageRightContentZone.AddRegion(detailRegion2);

            #endregion

            DomainRepositories.RepositoryAssistant.Flush();

            // content from Homepage links to about page
            var connection1 = RegionConnection.Factory.Create(aboutRegion1, WidgetActions.Detail);
            leftContentHPR1.AddConnection(connection1);

            //// Articles from homepage link to detail page
            //var connection2 = RegionConnection.Factory.Create(detailRegion1, WidgetActions.Detail);
            //rightContentHPR1.AddConnection(connection2);

            //// Articles from detail page link to this page
            //var connection3 = RegionConnection.Factory.Create(detailRegion1, WidgetActions.Detail);
            //detailRegion2.AddConnection(connection3);

            DomainRepositories.RepositoryAssistant.Flush();
        }

        private static void GenerateDemoDataArticles(Region articleRegion, Widget widgetInfo)
        {
            Console.Write("Generating Article...");
            IArticleRepository articleRepository = DomainRepositories.GetWidgetRepository<IArticleRepository>(widgetInfo);
            for (int index = 0; index < 10; index++)
            {
                string title = "Article " + (index + 1);
                string desc = "This is the artcile " + (index + 1);
                string content = "This is the artcile " + (index + 1) + ". No more content...";

                Article art = Article.Factory.Create(title, desc, content);
                articleRepository.Save(art);

                art.AddRegion(articleRegion);
            }

            DomainRepositories.RepositoryAssistant.Flush();
        }

        private static void GenerateDemoDataFileContents(Region articleRegion, Widget widgetInfo)
        {
            Console.Write("Generating FileContent...");
            IFileContentRepository fileContentRepository = DomainRepositories.GetWidgetRepository<IFileContentRepository>(widgetInfo);
            for (int index = 0; index < 10; index++)
            {
                string name = "File" + (index + 1) + ".txt";
                string title = "This is the file " + (index + 1);
                string content = "This is the file " + (index + 1) + ". No more content...";

                FileContent file = FileContent.Factory.Create(name, title, string.Empty);
                file.Base64Content = DomainServices.Encryption.Encrypt(content, EncryptionOption.Base64);
                file.Type = DomainRepositories.ListValue.FindByName(ListValueConstants.FileTypes.PlainText);
                fileContentRepository.Save(file);

                file.AddRegion(articleRegion);
            }

            DomainRepositories.RepositoryAssistant.Flush();
        }
    }
}
