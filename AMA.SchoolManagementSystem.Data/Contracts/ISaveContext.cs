namespace AMA.SchoolManagementSystem.Data.Contracts
{
    public interface ISaveContext
    {
        MsSqlDbContext Context { get; }

        void Commit();
    }
}