namespace GDNET.Common.Data.Impl
{
    public abstract class RepositoryAssistant : IRepositoryAssistant
    {
        public abstract void BeginTransaction();
        public abstract void Commit();
        public abstract void Rollback();
        public abstract void Flush();
        public abstract void Clear();
        public abstract void FlushAndClear();
    }
}
