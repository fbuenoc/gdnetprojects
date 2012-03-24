namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithModification : IEntityWithActiveBase
    {
        bool IsDeletable
        {
            get;
            set;
        }

        bool IsEditable
        {
            get;
            set;
        }

        bool IsViewable
        {
            get;
            set;
        }
    }

    public interface IEntityWithModification<TId> : IEntityWithActiveBase<TId>, IEntityWithModification
    {
    }
}
