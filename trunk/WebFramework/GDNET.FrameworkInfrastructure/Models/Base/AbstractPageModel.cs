namespace GDNET.FrameworkInfrastructure.Models.Base
{
    public abstract class AbstractPageModel
    {
        public AbstractPageModel()
        {
            this.PageMeta = new PageMetaModel();
        }

        public PageMetaModel PageMeta
        {
            get;
            private set;
        }
    }
}
