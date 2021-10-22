using System;
using System.Collections.Generic;

namespace DictionaryGenericClasses2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>() { 12, 14, 25, 67 };
           
            
            
            Dictionary<int, string> Teachers = new Dictionary<int, string>()
            {
                {210,"Serhat" },
                {211,"Ahmet" },
                {212,"Orhan" }
            };

            Console.WriteLine($"TEachers-210:  { Teachers[210]}");
            foreach (var number in numbers)
            {
                Console.WriteLine("Number: " + number);
            }

            Dictionary<int, string> Students = new Dictionary<int, string>();
 
            Students.Add(110, "Adem");
            Students.Add(111, "Zeynep");
            Students.Add(112, "Zehra");
            //Burda girdigimiz index numarasini key gibi dusunelim, value da bizim girdigimiz deger. Burda key numarasi bizim
            // o value ya ulasmamiz icin veriliyor cunku biz burda dizi veya generic listelerdeki gibi dizi indexi ile elemana
            // ulasamiyoruz
            //Iste bu sekilde verdigimiz degerlere yine kendi atadigmiz index numaralari ile key ile ulasabiliriz
            Console.WriteLine(Students[110]);     
            Console.WriteLine(Students[111]);
            Console.WriteLine(Students[112]);

            Console.WriteLine("Students: "+  Students);
            //Tum degerleri de bu sekilde yazdiririz
            foreach (var student in Students)
            {
                Console.WriteLine("student: "+ student +"|"+"student.key: " +student.Key +"student.Value: " + student.Value);


                if ((student.Value == Students[student.Key]))
                {
                    Console.WriteLine("Student.Value esittir Students[student.Key] ");
                }
                else
                {
                     
                    Console.WriteLine("Student.Value esit degildir Students[student.Key]");
                }
                
                
            }

            Console.ReadLine();
        }
    }
}
