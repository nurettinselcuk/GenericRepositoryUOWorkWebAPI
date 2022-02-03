using GenericRepositoryUOWorkWebAPI.Data;
using GenericRepositoryUOWorkWebAPI.Services;

namespace GenericRepositoryUOWorkWebAPI.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly APIDBContext _context;
        private readonly ILogger _logger;

        public IPersonelRepository Personel { get; private set; }

        public UnitOfWork(APIDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Personel = new PersonelRepository(context, _logger);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
