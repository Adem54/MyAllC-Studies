using Inheritancess2;
using System;

namespace InterfaceInheritBirlikteKullan
{
    class Program
    {
        static void Main(string[] args)
        {


            Person person2 = new Person();//Inheritance de inherit alinan class somuttur ve tek basina newlenebilir
            //yani tek basina da bir anlam ifade ediyor ama interface tek basina soyuttur tek basina bir anlami yoktur
            person2.FirstName = "Kazim";
            Person person1 = new Customer();
            person1.FirstName = "Arda";
            Person person3 = new Student();
            person3.FirstName = "Nihat";

            Person[] persons = new Person[3] { person1, person2, person3 };

            foreach (var person in persons)
            {
                Console.WriteLine(person.FirstName);
            }


            Customer customer1 = new Customer();
            customer1.FirstName = "Alexandir";


            Console.WriteLine(customer1.FirstName);

            Console.ReadLine();
        }
    }
}

//INHERITANCE ILE INTERFACE FARKLARI NA BAKALIM....
//Inheritance-Kalitim,miras anlamina gelir
//interface lerde birer inheritance gibi calisirlar ama interface ler implement edilirler inherit degil
//Interfaceler newlenemez ama inherit alina class newlenebilir
//Biz bir class a birden fazla inherit alamayiz ama birden falza interface i implement edebilirz
//Interface lerde biz sadece imza tutabiliriz ama inherit alinan class ta ise methodun bloguyla beraber tutabiliriz
//Interface ler daha cok operasyonlarda, veya methodlarda kullanilirken inherit alindan class lar ise daha cok propery 
//class lari icin kullanilirlar
//Biz bir class ile hem bir interface i implement edip hem de baska bir class i inherit alabiliriz.....Dikkat etmemiz gereken
//bu tur durumlarda once inheritanca alinan class yazilir daha sonra virgul koyarak interfaceler getiriilir
//Bir class da ya property olur ya da method olur ikisi birlikte bir class ta olamazz....
//Abstract siniflarla calisirken inheritance kullanmaliyiz ama genellikle operasyonlarla calisirken veya methodlarla 
//calisirken interface ler kullanilir ama properties ler le de calisirken interface ler kullanilabilir....
//Eger inheritance kullanmak icin zorunlu oldugumuzu dusunmuyorsak interface leri kullanabilirizz...
//Inheritance de ici doldurulmus bir methodu onu inherit edenler kullanabiliyor ama onu inherit edenlerin hepsi ayni
//methodu kullaniyor ancak inheritance da biz methodun sadece imzasini atiyoruz icini doldurmuyoruz icini o interface i
//implement eden class lar kendi sartlarina kendi kurallarina gore icini dolduruyorlar yani method isminin Add olmasi
//bizi yaniltmasin o Add isimli method un icini her class kendisi dolduruyor icerikler farklidir iste bu inheritance ile
//interface arasindaki onemli bir farktir
//Class ta inherit ---interface de implement denir
//Interface biz bir sablon belirleriz ve o interface i implement eden class lar o sablona uymak zorundadir deriz 
//Tabi ki  o sablonlarin iciini istedikleri gibi doldurabilirler
//Interface ler new lenemez
//