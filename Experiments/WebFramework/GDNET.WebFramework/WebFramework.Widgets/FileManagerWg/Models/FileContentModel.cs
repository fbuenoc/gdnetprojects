using WebFramework.Common.Framework.Base;
using WebFramework.Widgets.Domain.FileWg;

namespace WebFramework.Widgets.FileManagerWg.Models
{
    public class FileContentModel : ModelEntityBase<FileContent, long>
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public FileContentModel()
            : base()
        {
        }

        public FileContentModel(FileContent file)
            : base(file)
        {
            this.Name = base.Entity.Name;
            this.Description = base.Entity.Description;
        }
    }
}