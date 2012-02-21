namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithModification
    {
        bool IsActive
        {
            get;
            set;
        }

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

    public interface IEntityWithModification<TId> : IEntityBase<TId>, IEntityWithModification
    {
    }
}
