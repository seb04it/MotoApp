namespace MotoApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using MotoApp.Data.Entities;

    public class MotoAppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<BuisinessPartners> BuisinessPartners => Set<BuisinessPartners>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
