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

            public FileContent Create(string name, string description, string base64Content)
            {
                ThrowException.ArgumentExceptionIfNullOrEmpty(name, "name", "Name can not be nullable.");
                ThrowException.ArgumentExceptionIfNullOrEmpty(base64Content, "base64Content", "Base64Content can not be nullable.");

                var file = new FileContent
                {
                    Name = name,
                    Description = description,
                    Base64Content = base64Content
                };

                file.LifeCycle.AddStatutLog(StatutLog.Factory.Create(string.Empty));

                return file;
            }
        }
    }
}

