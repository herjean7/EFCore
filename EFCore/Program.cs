using EFCore.Context;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {

            //InsertData();
            ParameterisedQuery();
            QueryData();

            UpdateData();

            QueryData();
        }

        private static void InsertData()
        {
            using (var context = new SchoolContext())
            {
                //EF - ADD
                Student std = new Student() { Name = "Summy", Gender = 'M' };
                context.Students.Add(std);
                Instructor inst = new Instructor() { InstructorName = "Fandhi Sukha" };
                context.Instructors.Add(inst);


                //EF - ADD RANGE
                var courseList = new List<Course>()
                {
                    new Course(){CourseName="Geography"},
                    new Course(){CourseName="English Language"}
                };
                context.Courses.AddRange(courseList);

                context.SaveChanges();
            }
        }

        private static void QueryData()
        {
            using (var context = new SchoolContext())
            {
                var stud = context.Students
                                .Where(s => s.StudentId == 1)
                                .FirstOrDefault();

                Console.WriteLine(stud.StudentId + "|" + stud.Name + "|" + stud.Gender);
            }
        }

        private static void ParameterisedQuery()
        {
            string name = "Herjean";
            //QUERY USING PARAMETERISED QUERIES TO PREVENT SQL INJECTION
            using (var context = new SchoolContext())
            {
                var stud = context.Students
                                .FromSqlRaw($"Select * from Students where Name like '%{name}%'")
                                .FirstOrDefault();

                Console.WriteLine(stud.StudentId + "|" + stud.Name + "|" + stud.Gender);
            }
        }

        private static void UpdateData()
        {
            using (var context = new SchoolContext())
            {
                var stud = context.Students.Find(1);
                stud.Name = "Herjean";
                context.SaveChanges();
            }
        }
    }
}
