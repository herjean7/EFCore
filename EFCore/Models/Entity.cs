using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EFCore.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        //ONE COURSE WILL HAVE ONE INSTRUCTOR
        public Instructor Instructor { get; set; }
    }

    //DEFINE MANY TO MANY RELATIONSHIP
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }

    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        //ONE INSTRUCTOR CAN TEACH MANY COURSES
        public List<Course> Courses { get; set; }
    }
}
