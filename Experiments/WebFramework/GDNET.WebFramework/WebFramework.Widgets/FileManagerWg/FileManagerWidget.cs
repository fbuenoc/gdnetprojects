using System.Linq;
using WebFramework.Common.Widgets;
using WebFramework.Domain;
using WebFramework.Widgets.Domain.FileWg.Repositories;

namespace WebFramework.Widgets.FileManagerWg.Models
{
    public class FileManagerWidget : WidgetBase<FileManagerModel>
    {
        public override string Code
        {
            get { return "71095034-587B-490D-98CE-6527D7565E47"; }
        }

        protected override FileManagerModel InitializeModel()
        {
            FileManagerModel model = base.InitializeModel();

            var currentRegion = base.GetCurrentRegion();
            var fileContentRepository = DomainRepositories.GetWidgetRepository<IFileContentRepository>(base.GetWidgetInfo());
            var listOfFiles = fileContentRepository.GetAllByRegion(currentRegion).Select(x => new FileContentModel(x)).ToList();
            listOfFiles.ForEach(x => model.FileContents.Add(x));

            return model;
        }

        protected override void RegisterProperties()
        {
            base.RegisterProperties();
        }
    }
}