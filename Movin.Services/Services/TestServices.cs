using AutoMapper;
using Movin.Database;
using Movin.Database.Entity;
using Movin.Dto.Test;
using Movin.Exception;
using Movin.Services.IServices;

namespace Movin.Services.Services
{
    public class TestServices : ITestServices
    {
        private readonly MovinDbContext _dbContext;
        private readonly IMapper _mapper;

        public TestServices(MovinDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public Test GetHostById(int id) => _dbContext.Tests.FirstOrDefault(x => x.Id == id);
        public IEnumerable<TestListDto> GetListDto(string options)
        {
            if (options != "All" && options != "Disable" && options != "Enable")
                throw new InCorrectQueryParseException("You can only choose All, Disable, Enable");
            var list = _mapper.Map<List<TestListDto>>(_dbContext.Tests.ToList());
            if (options == "All")
                return list;
            return options == "Enable" ? list.Where(x => x.TestEnable) : list.Where(x => x.TestEnable == false);
        }

        public IEnumerable<Test> GetActiveTest() => _dbContext.Tests.Where(x => x.TestEnable);
        public bool AddTest(TestDto dto)
        {
            Test test = _mapper.Map<Test>(dto);
            if (_dbContext.Tests.Any(x => x.TestName == dto.TestName))
                return false;
            _dbContext.Tests.Add(test);
            _dbContext.SaveChanges();
            return true;
        }

        public TestDto GetTestDto(int id)
        {
            var test = _dbContext.Tests.FirstOrDefault();
            if (test is null) throw new NotFoundException("Test not found");
            return _mapper.Map<TestDto>(test);
        }
    }
}
