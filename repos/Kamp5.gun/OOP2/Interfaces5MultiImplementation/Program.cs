using System;
using System.Collections.Generic;

namespace Interfaces5MultiImplementation
{
    class Program
    {
        //INTERFACE LERIN DOGRU PLANLANMASI!!!!!
        //SOLID IN 4.PRENSIBINE GORE INTERFACELERIN DOGRU PLANLANMASI GEREKIR
        static void Main(string[] args)
        {

            Employee employee1 = new Employee();
            Manager manager1 = new Manager();
            Robot robot1 = new Robot();

            //Olusturacagimiz diziyi biz interface tipinde olusturursak eger onlari implement eden clss larin intancelerini
            //o listelere atabiliriz ancak biz listeyi hangi interface ile olusturursak ancak o interface deki
            //imzasi olan methodlari cagirabiliriz onun icin ihtiyaca gore tekrardan implemente edilen diger interface lerle
            //de liste veya dizi olusturmak gerekebilir....
            IWorker[] workers = new IWorker[3] {employee1,manager1,robot1};
            List<IEat> workers2 = new List<IEat>() { employee1, manager1 };
            List<IGetSalary> workers3 = new List<IGetSalary>() { employee1, manager1 };

            foreach (var worker in workers)
            {
                worker.Work();//IWorker ile olusturulmus bir interface de sadece Work() imzasi old icin
                              //sadece Work() methodu gelir
            }

            Console.WriteLine("---------------------------------------------------------------------");
            foreach (var worker in workers2)
            {
                worker.Eat();//IEat interface i ile olusturulmus bir interface de sadece Eat() imzasi old icin sadece
                //Eat() methodu gelir
               

            }
            Console.WriteLine("-------------------------------------------------------------");

            foreach (var worker in workers3)
            {
                worker.GetSalary();//IGetSalary interface i ile olusturulmus bir interface de sadece GetSalary() imzasi old
                //icin sadece GetSalary() methodu gelir
            }


            Console.ReadLine();
        }
    }
}
