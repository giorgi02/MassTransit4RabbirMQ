using ITA.SSA.Models;
using Microsoft.EntityFrameworkCore;

namespace ITA.SSA.EntityFramework
{

    public class DataContext : DbContext
    {
        public DbSet<Beneficiary> Beneficiaries { get; set; }


        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}