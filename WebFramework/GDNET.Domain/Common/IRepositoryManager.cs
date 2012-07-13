namespace GDNET.Domain.Base
{
    public interface IRepositoryManager
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        void Flush();
        void Clear();
        void FlushAndClear();
    }
}
