using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassIntroEks
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course1 = new Course() { CourseName = "C# kursu", CourseTeacher="Engin Demiroğ",CourseWatched= 56.5 };
            
            Course course2 = new Course();
            course2.CourseName = "Java kursu";
            course2.CourseTeacher = "Murat Yücedağ";
            course2.CourseWatched = 76.6;

            Course course3 = new Course();
            course3.CourseName = "Html kursu";
            course3.CourseTeacher = "Sinan Kaya";
            course3.CourseWatched = 61.2;

            //Bir tane Course classı array i oluşturduk biz ki ne için bizim class ımızdan oluşan instancelerimizi diziye atmak
            //için ve sonrasında da onların özelliklerine propertieslerine döngü ile birlikte ulaşabileceğiz
            Course[] courses = new Course[] { course1, course2, course3 };

            foreach (var course in courses)
            {
                Console.WriteLine(course.CourseName + course.CourseTeacher + course.CourseWatched);
            }

            Console.ReadLine();

        }
    }

    class Course
    {
        public string CourseName { get; set; }
        public string CourseTeacher { get; set; }
        public double CourseWatched { get; set; }
    }
}
