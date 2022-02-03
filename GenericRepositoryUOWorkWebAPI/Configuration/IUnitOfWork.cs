using GenericRepositoryUOWorkWebAPI.Services;

namespace GenericRepositoryUOWorkWebAPI.Configuration
{
    public interface IUnitOfWork
    {
        IPersonelRepository Personel { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
