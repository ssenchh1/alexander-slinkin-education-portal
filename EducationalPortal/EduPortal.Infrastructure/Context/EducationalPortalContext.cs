using System.Reflection;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;
using EduPortal.Domain.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Context
{
    public class EducationalPortalContext : IdentityDbContext<User>
    {
        public EducationalPortalContext()
        {
            Database.EnsureCreated();
        }

        public EducationalPortalContext(DbContextOptions<EducationalPortalContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<DigitalBook> DigitalBooks { get; set; }
        public DbSet<VideoMaterial> VideoMaterials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var conectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //optionsBuilder.UseSqlServer(conectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
