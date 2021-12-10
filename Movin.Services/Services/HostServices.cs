using AutoMapper;
using Movin.Database;
using Movin.Database.Entity;
using Movin.Dto.Host;
using Movin.Services.IServices;

namespace Movin.Services.Services
{
    public class HostServices : IHostServices
    {
        private readonly MovinDbContext _dbContext;
        private readonly IMapper _mapper;

        public HostServices(MovinDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Host GetHostById(int id) => _dbContext.Hosts.FirstOrDefault(x => x.Id == id);
        public IEnumerable<HostDto> GetHostDtoList() => _mapper.Map<List<HostDto>>(_dbContext.Hosts.ToList());
    }
}
