using System;
using WebFramework.Common.Widgets;

namespace WebFramework.Widgets.Models.FileManager
{
    public class FileManagerWidget : WidgetBase<FileManagerModel>
    {
        public override string Code
        {
            get { return "71095034-587B-490D-98CE-6527D7565E47"; }
        }

        public FileManagerWidget()
            : base()
        {
            base.BeforeInstalled += WidgetBeforeInstalled;
            base.AfterInstalled += WidgetAfterInstalled;
        }

        #region Events

        void WidgetBeforeInstalled(object sender, EventArgs e)
        {
        }

        void WidgetAfterInstalled(IWidget sender, WidgetEventArgs e)
        {
        }

        #endregion

        protected override FileManagerModel InitializeModel()
        {
            FileManagerModel model = default(FileManagerModel);
            return model;
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
        }
    }
}