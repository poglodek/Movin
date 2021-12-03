using Movin.Database.Entity;
using Movin.Dto.Test;

namespace Movin.Services.IServices;

public interface ITestServices
{
    Test GetHostById(int id);
    IEnumerable<TestListDto> GetListDto(string options);
    IEnumerable<Test> GetActiveTest();
}