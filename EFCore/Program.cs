using EFCore.Context;
using EFCore.Models;
using System;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {

            //InsertData();

            QueryData();

            UpdateData();

            QueryData();
        }

        private static void InsertData()
        {
            using (var context = new SchoolContext())
            {
                Student std = new Student() { Name = "Herjean", Gender = 'M' };
                context.Students.Add(std);

                Course cse = new Course() { CourseName = "Economics" };
                Course cse2 = new Course() { CourseName = "History" };

                context.Courses.Add(cse);
                context.Courses.Add(cse2);

                Instructor inst = new Instructor() { InstructorName = "Joseph Kwok" };
                context.Instructors.Add(inst);

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
