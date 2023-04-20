using AvanceradDotNetLabb4.Models;
using Microsoft.EntityFrameworkCore;

namespace AvanceradDotNetLabb4.Data
{
    public class ThisDbContext : DbContext
    {
        public ThisDbContext()
        {

        }

        public ThisDbContext(DbContextOptions<ThisDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source = THINKPAD; Initial Catalog=AvanceradDotNetLabb4;Integrated Security = True; TrustServerCertificate = True");
        }

        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestPerson> InterestsPersons { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
