using System.Collections.Generic;
using WebFramework.Common.Common;
using WebFramework.Common.Framework.System;
using WebFramework.Common.Widgets;
using WebFramework.Widgets.FileManagerWg.Controllers;
using WebFramework.Widgets.FileManagerWg.Models;

namespace WebFramework.Widgets.FileManagerWg
{
    public class FileManagerModel : WidgetModelBase
    {
        private IList<FileContentModel> fileContents = new List<FileContentModel>();

        public FileManagerModel(RegionModel regionModel)
            : base(regionModel)
        {
        }

        public IList<FileContentModel> FileContents
        {
            get { return this.fileContents; }
        }

        public override bool CanManage
        {
            get
            {
                return FrameworkServices.Authorization.ActionIsAllowedForUser(typeof(AdminController).FullName, AdminController.ActionList);
            }
        }
    }
}