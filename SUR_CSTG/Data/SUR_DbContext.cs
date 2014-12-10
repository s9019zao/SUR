using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUR_CSTG.Data
{
    public class SUR_DbContext : DbContext
    {
        public SUR_DbContext()
            : base("name=SurDb")
        {
            Database.SetInitializer<SUR_DbContext>(new Initializer());
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Part> Parts { get; set; }
    }
}
