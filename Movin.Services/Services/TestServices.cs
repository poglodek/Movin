using Movin.Database;
using Movin.Database.Entity;
using Movin.Services.IServices;

namespace Movin.Services.Services
{
    public class TestServices : ITestServices
    {
        private readonly MovinDbContext _dbContext;

        public TestServices(MovinDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Test GetHostById(int id) => _dbContext.Tests.FirstOrDefault(x => x.Id == id);
    }
}
