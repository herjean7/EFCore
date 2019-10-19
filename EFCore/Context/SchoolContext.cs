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
    }
}
