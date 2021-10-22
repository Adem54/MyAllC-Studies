using EfCodeFirstDataAnnotation.Context;
using EfCodeFirstDataAnnotation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EfCodeFirstDataAnnotation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                List<Musteri> musteriler = context.Musteriler.ToList();
                foreach (var musteri in musteriler)
                {
                    Console.WriteLine(musteri.Ad);
                }
            }

            Console.ReadLine();
        }
    }
}
