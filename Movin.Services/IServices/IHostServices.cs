using Movin.Database.Entity;

namespace Movin.Services.IServices;

public interface IHostServices
{
    public Host GetHostById(int id);
}