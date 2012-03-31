namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithModification : IEntityWithActive
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
    }
}
