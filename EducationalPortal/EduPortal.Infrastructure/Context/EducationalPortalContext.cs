using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduPortal.Domain.Models;
using EduPortal.Domain.Models.Materials;
using EduPortal.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Infrastructure.Context
{
    public class EducationalPortalContext : DbContext
    {
        public EducationalPortalContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
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
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3RQFHH4\SQLEXPRESS01;Initial Catalog=EducationPortal;Integrated Security=True");
        }
    }
}
