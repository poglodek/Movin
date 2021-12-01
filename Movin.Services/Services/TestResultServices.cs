using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movin.Database;
using Movin.Database.Entity;
using Movin.Dto.TestResult;
using Movin.Services.IServices;

namespace Movin.Services.Services
{
    public class TestResultServices : ITestResultServices
    {
        private readonly MovinDbContext _dbContext;

        public TestResultServices(MovinDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveTestResult(TestResultDto dto)
        {

        }
    }
}
