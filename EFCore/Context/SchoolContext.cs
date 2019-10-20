using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=SchoolDB;Trusted_Connection=True;");
        }

        //Overriding OnModelCreating to create relationships using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //DEFINE MANY-TO-MANY RELATIONSHIP
            modelBuilder.Entity<StudentCourse>()
                .HasKey(pt => new { pt.StudentId, pt.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(st => st.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(st => st.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(cs => cs.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(cs => cs.CourseId);

            //DEFINE ONE-TO-MANY RELATIONSHIP
            modelBuilder.Entity<Course>()
                .HasOne(cs => cs.Instructor)
                .WithMany(i => i.Courses);
        }
    }
}
