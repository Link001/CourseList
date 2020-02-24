using Microsoft.EntityFrameworkCore;
using System;


namespace WebSwash
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> dbContextOptions)
                    : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Entity<Course>().Property(c => c.Date);
        }
    }

}
