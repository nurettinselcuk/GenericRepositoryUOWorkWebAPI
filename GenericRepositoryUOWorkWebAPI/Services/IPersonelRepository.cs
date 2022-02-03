using GenericRepositoryUOWorkWebAPI.Model;

namespace GenericRepositoryUOWorkWebAPI.Services
{
    public interface IPersonelRepository : IGenericRepository<Personel>
    {
        Task<int> KaçPersonelVar();



    }
}
