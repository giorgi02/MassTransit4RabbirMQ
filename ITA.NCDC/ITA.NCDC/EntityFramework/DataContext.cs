using ITA.NCDC.Contracts;
using ITA.NCDC.Models;
using Microsoft.EntityFrameworkCore;

namespace ITA.NCDC.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<Laboratory> Laboratories { get; set; }

        public DbSet<Beneficiary> _Beneficiaries { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=localhost; Database=ITA.NCDC; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}