namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithActive : IEntityBase
    {
        bool IsActive
        {
            get;
            set;
        }
    }
}
