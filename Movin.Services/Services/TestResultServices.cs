using AutoMapper;
using Movin.Database;
using Movin.Database.Entity;
using Movin.Dto.TestResult;
using Movin.Exception;
using Movin.Services.IServices;

namespace Movin.Services.Services
{
    public class TestResultServices : ITestResultServices
    {
        private readonly MovinDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IHostServices _hostServices;
        private readonly ITestServices _testServices;

        public TestResultServices(MovinDbContext dbContext,
            IMapper mapper,
            IHostServices hostServices,
            ITestServices testServices)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _hostServices = hostServices;
            _testServices = testServices;
        }

        public void SaveTestResult(TestResultDto dto)
        {
            var entity = _mapper.Map<TestResult>(dto);
            var host = _hostServices.GetHostById(dto.HostId);
            var test = _testServices.GetHostById(dto.TestId);
            entity.Host = host ?? throw new NotFoundException("Host not found");
            entity.Test = test ?? throw new NotFoundException("Test not found");
            _dbContext.Results.Add(entity);
            _dbContext.SaveChanges();
        }
    }
}
