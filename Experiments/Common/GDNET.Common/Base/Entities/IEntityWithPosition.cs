namespace GDNET.Common.Base.Entities
{
    public interface IEntityWithPosition
    {
        int? Position { get; }
        void MoveUp();
        void MoveDown();
    }
}
