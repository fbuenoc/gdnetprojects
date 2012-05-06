namespace WebFramework.Domain.Base
{
    public abstract class DTOEntityBase<TId> : IDTOEntity<TId>
    {
        public TId Id
        {
            get;
            protected set;
        }

        public abstract void BuildDTO(object[] objects);
    }
}
