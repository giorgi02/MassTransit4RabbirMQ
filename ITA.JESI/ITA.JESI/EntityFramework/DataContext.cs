using ITA.JESI.Contracts;
using ITA.JESI.Models;
using Microsoft.EntityFrameworkCore;

namespace ITA.JESI.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<Beneficiary> _Beneficiaries { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}