using Movin.Database.Entity;

namespace Movin.Services.IServices;

public interface ITestServices
{
    public Test GetHostById(int id);
}