using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
    }
}
