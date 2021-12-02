using Movin.Database.Entity;
using Movin.Dto.Test;

namespace Movin.Services.IServices;

public interface ITestServices
{
    Test GetHostById(int id);
    IEnumerable<TestDto> GetListDto(string options);
}