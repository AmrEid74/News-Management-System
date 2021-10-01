using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using News.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Database
{
   public class DemoContext: IdentityDbContext<ApplicationUser>
    {
      

        public DemoContext(DbContextOptions<DemoContext> opts ):base(opts){}

        public DbSet<User> User { get; set; }
        public DbSet<Categories> Categories { get; set; }

        public DbSet<Newss> Newss { get; set; }

    }
}
