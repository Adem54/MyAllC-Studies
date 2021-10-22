using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //ProductManager productManager = new ProductManager(new EfProductDal());
            PersonelManager personManager = new PersonelManager(new EfPersonelDal());
            foreach (var personel in personManager.GetAll())
            {
                Console.WriteLine(personel.Name + " | "+ personel.SurName);
            }

            Console.ReadLine();
        }
    }
}
