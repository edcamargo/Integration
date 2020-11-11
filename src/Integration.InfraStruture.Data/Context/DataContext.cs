using Integration.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Integration.InfraStruture.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        #region DbSet

        public DbSet<Employee> Employee { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Mappings
            //modelBuilder.ApplyConfiguration(new EmployeeMap());
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
