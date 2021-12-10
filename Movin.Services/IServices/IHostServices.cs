using Movin.Database.Entity;
using Movin.Dto.Host;

namespace Movin.Services.IServices;

public interface IHostServices
{
    public Host GetHostById(int id);
    IEnumerable<HostDto> GetHostDtoList();
}