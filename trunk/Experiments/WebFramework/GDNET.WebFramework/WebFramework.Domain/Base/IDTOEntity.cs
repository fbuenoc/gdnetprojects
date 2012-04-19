namespace WebFramework.Domain.Base
{
    public interface IDTOEntity<TId>
    {
        TId Id { get; }
        void BuildDTO(object[] objects);
    }
}
