namespace GDNET.Common.Data
{
    public interface IRepositoryAssistant
    {
        void BeginTransaction();
        void Commit();
        void Rollback();

        void Flush();
        void Clear();
        void FlushAndClear();
    }
}
