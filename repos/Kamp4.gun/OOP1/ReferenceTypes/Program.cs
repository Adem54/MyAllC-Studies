using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceBoxing
{

    class Program
    {
        static void Main(string[] args)
        {
            //int,decimal,double,float,bool sayisal ola degiskenler degertiplerdir
            //array,class,interface,generic collectors referanse type lerdir

            Person person1 = new Person();
            person1.Id = 123;
            person1.FirstName = "Kamil";
            person1.LastName = "Karabacak";
            Person person2 = new Person();
            person1 = person2;
            //person1 ve person2 ayni class tan olustugu icin birbirine atama yapabiliriz
            person2.FirstName = "Kemalettin";
            Console.WriteLine($"person1.FirstName= {person1.FirstName}");
            //Referans tip  old icin person1.FirstName de Kemalettin olur cunku person1 e person2 nin ref adresini atadik

        
            Customer customer1 = new Customer();
            Employe employe1 = new Employe();
            //ONEMLI DIKKAT EDILMELI!!!!FARKLI CLASS DEGISKENLERI BIRBIRNE ATANAMAZ(ISTISNASI INHERITANCE)
            // customer1 = employe1;=>Boyle bir esitligi asla yapamayiz cunku farkli class lardan yani farkli tiplerden olusturulmus
           //degiskenler birbrine atanamaz, nasil ki string degisken int degiskene atanamazsa burda da ayni durum vardir
            customer1.FirstName = "Mehmet";
            employe1.LastName = "Yerli";
            Console.WriteLine(person1.Id);
            Console.WriteLine( customer1.FirstName);
            Console.WriteLine(employe1.LastName);
            //INHERITANCE ALINAN CLASS DEGISKENINE ONU INHERITANCE ALAN CLASS INSTANCELERI ATAMASI YAPILABILIR
            //Person class i hem Customer class inin hem de Employe clasi tarafinda inheritance alindigi icin yani babalari old icin
            //biz person class indan olusturulmus degiskenlere onu inheritance alan Class tan olusturulmus nesne veya instanceler 
            //atayabiliriz. Ama tam tersi yapamayiz yani Customer ve Employe class indan olusturulmus degiskene Person class indan
            //olusturulmus instance veya nesne atamasi yapamayiz, yani babasini onlara atayamayiz
            customer1.CrediCartNumber = 1234567;
            person1 = customer1;//customer class i da artik bir person class idir hatta person class inin haricinde de propertisi var
            // yani person class i ve fazlasi da var dolayisi ile Person class indan olusturulmus bir degiskene customer instancesi
            //karsilik gelebiliyor cunku fazlasi var eksigi yok :) ama customer class indan olusturulmus bir degiskeni Person class
            //indan olusturulan bir instance karsilaayamiyor cunku person onlarin babalari babalarin ozelliklerinin tamamini almislar 
            //ekstra da kendilerine ozel ozellikleri var
            //PERSON BASE CLASS TIR.TEMEL SINIF-EBEVEYN SINIF
            //EBEVEYNE YANI BASE CLASSS A ONU INHERITE EDEN SINIFLARIN REFERANSINI ATAYABILIYORUZ,ADRESINI ATAYABILIRIZ
            employe1.EmployeNumber = 987654;
            person2 = employe1;
         //PERSON CUSTOMER VE EMPLOYE TARAFINDAN INHERITANCE ALININCA, CUSTOMER VE EMPLOYE DE ASLINDA BIR PERSON OLMUS OLUYOR

            //customer1 = person1;=BU ATAMA YAPILAMAZ
            //employe1 = person2;=>BU ATAMA YAPILAMAZ
            Console.WriteLine("-------------------------");
            Console.WriteLine("person1 in FirstName "+person1.FirstName);
            Console.WriteLine("person2 in LastName "+ person2.LastName);
            //Peki biz person2 uzerinden giderek sadece employe1 e ait ozellik olan EmployeNumber a ulasabilir miyiz?
            //Dogrudan person2 uzerinden employe1 e ait ozellie ulasamayiz cunku Person1 sablonu kendi barindirdigi ozelliklere
            //erisebiliyor ancak biz eger person2 ye employe class boxing i yaparsak o zaman employe ye ozel olan propertye de
            //person2 tarafindan erisebiliriz
            //BOXING YAPARAK person2 uzerinden de employe1 in tum ozelliklerine ulasma
            //BOXING- ILE PERSON CLASS I DEGISKENINDEN DE ONU INHERITANCE ALAN CLASS INSTANCELERININ TUM DEGERLERINE ULASMA!!!!!
            Console.WriteLine("CrediCartNumber:  "+ ((Employe)person2).EmployeNumber);


            //PERSONMANAGER DA PARAMETREYE ISTEDIGIM PROPERTY CLASS INI VEREBILIYORUM-PERSON I DIGER CLASS LAR TARAFINDAN
            //INHERIT EDILDIKEN SONRA PARAMETRE OLARAK PERSON VERINCE ARTIK DIGER CLASSLARI DA PARAMETREDE KULLANABILIYORUZ
            PersonManager personManager = new PersonManager();
            personManager.Add(person1);
            personManager.Add(customer1);
            personManager.Add(employe1);
            //Ayni kodu farkli nesneler icin kullanabilme firsatini veriyor bize
            //Ornegin 3 tane farkli veritabani ile calismak zorunda kaldigimiz zaman herbirisi icin bir suru kod yazmak yerine
            //herbirisinin kendi nesnelerini olusturup onlardan istedigimizi calistiracagiz ve kendimizi
            //tekrar etmekten kurtulmus olacagiz
            //PERSON CLASS INI DIEGER PROPERTY CLASS LARI INHERITANCE ALDIKLARI ZAMAN PERSON ONLARIN DA REFERANS INI , ADRESINI 
            //TUTABILIYOR,BABALARI OLD ICIN , INHERITANCE ALINDIGI ICIN PERSON ONLARIN REFERANSINI TUTABILIYOR
           //Bizim yukarda Add methodu icerisine customer ve employee instancelerini koyabilmemiz aslinda altta person3 ve person4
           //degiskenlerine customer dan  ve employe den olusturulan adresleri  tutturmus olmamizla ayni seydir
            Person person3 = new Customer();
            Person person4 = new Employe();
            
            
            
            
            Console.ReadLine();

          



        }
    }
    //PROPERT CLASS LARINI NASIL AYARLARIZ VE INHERITANCE OLAYI ILE BIZ HANGI KOLAYLIKLARI SAGLAMIS OLURUZ
    //Oncelikle biz bir projede entities varliklar adi verilebilen veya Person,Customer,Employe gibi isimli class larda properties
    //lerimizi tutariz.Biz class lari 2 amac icin kullaniyorduk 1 i propertieselerimizi tutumak, digeri de method veya operasyonlari
    //tutmak icindi
    //Propertieslerimizi tutarken de belli pratikk ve surdurulebilir yontemlerle yapariz bunu nasil soyle ki once Person class i gibi
    //bir tane diger tum property class larimizin hepsi icin gecerli olan bir Person class i olusturur ve onun icerisinde
    //diger property class larininda kullanacagi ozellikleri biz herbirisinde ayri ayri tutmak yerin e Person adinda bir class
    //olustururuz ve oraya tum property class larinin ortak property lerini oraya atariz ve Person class ini da diger property class
    //larina inheritance olarak veririz yani Person i diger class larin babasi yapariz ve bu sekilde yaparak neleri saglamis oluruz:
    //Diger class lar Person class ini inheritance alarak, miras alarak:
    //1-Diger class lar Person class inin icindeki tum ozelliklere dogrudan erismesini saglamis oluruz ki bu zaten olmali cunki biz
    //ortak property leri burda tuttuk
    //2-Biz bir operasyon class i yazdigimiz zaman parametre olarak ne verecegiz Person mu, Customer mi yoksa Employe mi, iste 
    //bu tarz durumlarda da parametre olarak Person verirsek  o zaman diger tum class larinda parametre olarak kullanilabilmesini
    //saglamis oluruz cunku miras olarak alinan class(Person clasindan) tan olusturulan ddegiskene biz miras aldigi class tan olusturulan bir nesne 
    //instance(Customer veya Employe) atayabiliyoruz.Dolayisi ile biz Person i parametre olarak veririz ama Person i parametre
    //olarak verince artik diger property class  larini da parametre de kulllanabilirim
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
      
    }

    public class Customer:Person
    {
        public int CrediCartNumber { get; set; }
    }

    public class Employe:Person
    {
        public int EmployeNumber { get; set; }
    }

    public class PersonManager
    {
        //Biz Add methoduna parametre olarak Customer gondersek sadece Customer ile calisabiliriz Employe class i ile calisamayiz
        //Sadece Employe gondersek bu seferde Customer ile calisamayiz ama Person classi ve degiskeni gonderirsek , biz Person
        //Person class degiskenine hem Customer hem de Employee atayabildigimiz icin biz parametre de artik istedigimiz class
        //ile calisabiliriz ve istedigimiz tum verilere ulasabiliriz!!!!!!!!!!
        //Bize ayni kodu farkli nesneler icin kullanabilmemizi sagliyor bize
        public void Add(Person person)
        {
            Console.WriteLine(person.FirstName);
        }
    }
}

