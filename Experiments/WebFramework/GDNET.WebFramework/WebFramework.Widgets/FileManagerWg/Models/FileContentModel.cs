using WebFramework.Common.Framework.Base;
using WebFramework.Widgets.Domain.FileWg;

namespace WebFramework.Widgets.FileManagerWg.Models
{
    public class FileContentModel : ModelEntityBase<FileContent, long>
    {
        public FileContentModel()
            : base()
        {
        }

        public FileContentModel(FileContent file)
            : base(file)
        {
        }
    }
}