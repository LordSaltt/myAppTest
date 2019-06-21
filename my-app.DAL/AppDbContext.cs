using my_app.DAL.Entities;
using System.Data.Entity;

namespace my_app.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("TestDb")
        {

        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ProductionHistory> ProductionHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductionHistory>().HasRequired(t => t.Employee).WithMany().WillCascadeOnDelete(false);
        }

    }
}
