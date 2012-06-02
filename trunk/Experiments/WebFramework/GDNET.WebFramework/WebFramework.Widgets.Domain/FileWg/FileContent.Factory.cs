using GDNET.Common.DesignByContract;
using WebFramework.Domain.Common;

namespace WebFramework.Widgets.Domain.FileWg
{
    public partial class FileContent
    {
        public static FileContentFactory Factory
        {
            get { return new FileContentFactory(); }
        }

        public class FileContentFactory
        {
            public FileContent NewInstance()
            {
                return new FileContent();
            }

            public FileContent Create(string name, string title, string description)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(name, "name", "Name can not be nullable.");
                ThrowException.ArgumentExceptionIfNullOrEmpty(title, "title", "Title can not be nullable.");

                var file = new FileContent
                {
                    Name = name,
                    Title = title,
                    Description = description
                };

                file.LifeCycle.AddStatutLog(StatutLog.Factory.Create(string.Empty));

                return file;
            }
        }
    }
}

