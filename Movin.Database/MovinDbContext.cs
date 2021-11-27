using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movin.Database.Entity;


namespace Movin.Database
{
    public class MovinDbContext : DbContext
    {
        public MovinDbContext()
        {
            
        }
        public MovinDbContext(DbContextOptions<MovinDbContext> options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Movin;Trusted_Connection=True;");
            //for docker optionsBuilder.UseSqlServer("Server=sql-server;Database=HostelSystem;User=sa;Password=P@s5Word&;");
        }

        public DbSet<Host> Hosts { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> Results { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
