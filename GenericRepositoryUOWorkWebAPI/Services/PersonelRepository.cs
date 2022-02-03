using GenericRepositoryUOWorkWebAPI.Data;
using GenericRepositoryUOWorkWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GenericRepositoryUOWorkWebAPI.Services
{
    public class PersonelRepository : GenericRepository<Personel>, IPersonelRepository
    {
        public PersonelRepository(APIDBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Personel>> GetirHepsi()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Şu Hatalar Oluştu :", typeof(PersonelRepository));
                return new List<Personel>();
            }
        }
        public async Task<int> KaçPersonelVar()
        {
            try
            {
                return await _dbSet.CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Şu Hatalar Oluştu :", typeof(PersonelRepository));
                return 0;
            }
        }

     
    }
}
