using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movin.Database;

namespace Movin
{
    public class Services
    {
        public static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<MovinDbContext>(x => x.UseSqlServer("Server=.;Database=Movin;Trusted_Connection=True;"));
            //for docker
            //serviceCollection.AddDbContext<MovinDbContext>(x => x.UseSqlServer("Server=sql-server;Database=HostelSystem;User=sa;Password=P@s5Word&;"));
        }
    }
}
