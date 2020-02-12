using System;
using System.Data.Entity;

namespace WebSwash
{
    public class CourseContext : DbContext
    {
        public CourseContext()
            : base("DbConnection")
        { }

        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Properties<DateTime>()
             .Configure(c => c
             .HasColumnType("datetime2")
             .HasPrecision(0));
        }
    }

}
