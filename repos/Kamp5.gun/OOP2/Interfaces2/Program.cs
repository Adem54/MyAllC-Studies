using System;

namespace Interfaces2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PersonManager personManager1 = new PersonManager();

            Customer cutomer1 = new Customer() { FirstName = "Orhan", LastName = "Ray" };
            Employee employee1 = new Employee() { FirstName = "Kayahan", LastName = "Peri" };


            //Bir interface hic bir zaman new lenemez...Bir interface in instance si olusturulamaz

            //INTERFACE LER ONU IMPLEMENT EDEN CLASS LARIN REFERANSINI TUTABILIYOR.....
            IPerson person1 = new Customer();
            IPerson person2 = new Employee();
            IPerson person3 = new Student();
            personManager1.Add(cutomer1);
            personManager1.Add(employee1);
            //IPerson interface i onu implement eden class larin referansini tutabildigi icin biz PersonManager daki Add
            //operasyonunda parametre olarak interface verirsek eger o zaman bu methodu calistirirken parametreye biz onu imple
            //mente eden tum class lari verebiliriz ve bu sekilde biz o methodu tum class larin verileri icin kullanabilmis 
            //olacagiz....
            //Yarin oburgun yeni bir nesne ekledigimiz zaman hic sorun yasamadan sistemimize entegre edebiiyoruz mevcut
            //kodlara hic dokunmadan onu sistemimize entegre edebiliyoruzz....Surdurulebilirlik

            //Sistemimize sonradan dahil ettigimiz Student class ini mevcut kodlara hic dokunamadann entegre edebiliyoruz
            Student student1 = new Student() {FirstName="Johansen", LastName="Bringebær" };
            personManager1.Add(student1);

            Console.ReadLine();
        }
    }
}

