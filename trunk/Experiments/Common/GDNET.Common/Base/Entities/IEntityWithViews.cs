namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithViews
    {
        long Views { get; }
        void HasViewed();
    }
}
