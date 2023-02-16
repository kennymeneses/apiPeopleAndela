using Microsoft.EntityFrameworkCore;
using PeopleApiAndela.Models;

namespace PeopleApiAndela.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<People>()
                .HasKey(jp => jp.PersonId);
        }

        public DbSet<People> peoples { get; set; }
    }
}
