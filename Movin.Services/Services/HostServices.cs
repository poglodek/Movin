using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database;
using Movin.Database.Entity;
using Movin.Services.IServices;

namespace Movin.Services.Services
{
    public class HostServices : IHostServices
    {
        private readonly MovinDbContext _dbContext;

        public HostServices(MovinDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Host GetHostById(int id) => _dbContext.Hosts.FirstOrDefault(x => x.Id == id);
    }
}
