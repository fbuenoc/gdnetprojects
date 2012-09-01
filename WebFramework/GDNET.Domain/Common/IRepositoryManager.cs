namespace GDNET.Domain.Common
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
