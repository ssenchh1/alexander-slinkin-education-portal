﻿using EduPortal.Domain.Models.Joining;
using EduPortal.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduPortal.Infrastructure.MappingConfigurations
{
    public class StudentTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasOne(s => s.User).WithOne(u => u.Student).HasForeignKey("User");

            builder.HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<StudentCourse>(
                    sc => sc.HasOne(c => c.Course)
                        .WithMany(s => s.StudentCourses)
                        .HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict),
                    sc => sc.HasOne(c => c.Student)
                        .WithMany(cr => cr.StudentCourses)
                        .HasForeignKey(c => c.StudentId).OnDelete(DeleteBehavior.Restrict),
                    sc =>
                    {
                        sc.Property(c => c.EnrolledAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        sc.HasKey(t => new {t.StudentId, t.CourseId});
                    });

            builder.HasMany(s => s.FinishedCourses)
                .WithMany(c => c.FinishedStudents)
                .UsingEntity<StudentFinishedCourse>(
                    sc => sc.HasOne(c => c.Course)
                        .WithMany(c => c.StudentFinishedCourses)
                        .HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict),
                    sc => sc.HasOne(s => s.Student)
                        .WithMany(s => s.StudentFinishedCourses)
                        .HasForeignKey(s => s.StudentId).OnDelete(DeleteBehavior.Restrict),
                    sc =>
                    {
                        sc.Property(s => s.FinishedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
                        sc.HasKey(k => new {k.CourseId, k.StudentId});
                    });
        }
    }
}
