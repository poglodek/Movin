using Microsoft.EntityFrameworkCore;
using Movin.Database;
using Movin.Dto.TestResult;
using Movin.Services.IServices;


namespace Movin
{
    public class ServiceCollectionHelper
    {
        public static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MovinDbContext>(x => x.UseSqlServer("Server=.;Database=Movin;Trusted_Connection=True;"));
            //for docker
            //serviceCollection.AddDbContext<MovinDbContext>(x => x.UseSqlServer("Server=sql-server;Database=HostelSystem;User=sa;Password=P@s5Word&;"));
            serviceCollection.AddScoped<ITestResultServices,ITestResultServices>();
            serviceCollection.AddScoped<ITestServices,ITestServices>();
            serviceCollection.AddScoped<IHostServices,IHostServices>();
        }
    }

    
}
