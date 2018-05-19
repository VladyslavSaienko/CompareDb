using CompareDb.Models.EF;
using Microsoft.EntityFrameworkCore;

namespace CompareDb.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Hospital> EFHospitals { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=testSqlDb;Trusted_Connection=True;");
        }
    }
}
