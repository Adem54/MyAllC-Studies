using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            //Constructor da amacimiz bir class in olusma anini kontrol etmektir
            //Bir class i new ledigimiz zaman calisan bloktur constructor. Bir clas olustugu zaman constructor bir kez calisir bir 
            //daha calismaz. Karistirmayalim class olusurken new lendigi zaman bir kez calisir sonra o class icindeki methodlar
            //calistirildigi zaman calismaz
            //Constructor da aslinda bir methoddur
            //Constructor yapici blok demek yani bir class i ilkkez yapilandirdgimiz zaman calisan bloktur
            //Ozellikle class ilk new lendigi zaman olusturup sonra surekli kullanilabilecek liste ler icin kullanabiliriz

            //DEFAULT CONSTRUCTOR CALISIR
            Customer customer1 = new Customer {Id=23,FirstName="Mehmet",LastName="Kara",City="Skien" };
            Console.WriteLine(customer1.FirstName+"  | "+ customer1.LastName +" | "+customer1.City);

            Customer customer3 = new Customer();
            //Biz new Customer() deddigimiz zaman parantez acip kapariz sanki metod calistirir gibi iste bu constructor dan dolayi 
            //geliyor yani biz new ledigimiz zaman arka planda default constructor calisacaktir
            //ici bos olan bir constructor calisacakatir
            //CLASS NEW LERKEN KI BIR METHOD CALISTIRMA MANTIGINDA OLAN PARANTEZIMIZE DEGER YAZABILIR MIYIZ???
            // NEW LERKEN PARANTEZE DEGER KOYMAMIZ ICIN CONSTRUCTOR DA PARAMETRE VERILMESI GEREKIR, PEKI CONSTRUCTOR DA PARAMETRE
            //VERILIRSE EGER O ZAMAN DA BIZIM DEFAULT CONSTROCTOR UYGULAMADA IKEN BIZIM new Customer() parantez acip kapatip parantezi
            //bos birakarak olusturdugumuz class lar patlayacaktir yani bi aslinda bir constructor parametre atayarak default
            //constructor i ezmis oluruz

            //Peki her ikisini de kullanabilmek icin overloading seklinde yapariz yani methodlarda ayni ismi kulllanip sadece 
            //parametre sayisi vs degiserek ayni isimdde method yazmaya overloading diyorduk ayni sey burda da soz konusudur
            //Yani biz bu durumda bir tane de default olan parametresi olmayan icin bos olan constructor olustururuz
            //Parametresi olan constructor default constructor i ezmesin diye hem parametreli hemn de parametresiz yani default 
            //olan constructor i yazariz
           //PARAMETRE VEREREK OLUSTURDUGUMUZ CONSTROCTOR CALISIR
            Customer customer2 = new Customer(321, "Serhat", "Tere", "Oslo",5433);
            Console.WriteLine(customer2.FirstName);


            customer2.GetInfo();
            
            Console.ReadLine();
        }
    }

    class Customer
    {

        public Customer()
        {

        }//new lerken parantez ici bos olan class insanceleri patlamasin diye bir tane de default olarak olusturduk
        //otomatik constructor olusturmak icin ctor ve 2 kez tab a basarsak kendisi otomatik olusturacaktir
        //Constructor da bir methoddur aslinda
        //Biz bu constructor i burda ister yazalim ister yazmayalim o zaten arka planda default olarak calisacaktir
        //Class in ismii ile ayni sanki bir method gibi ama void veya herhangi birsey donmuyor
        public Customer(int id, string firstName, string lastName, string city,int customerNumber)
        {
            Console.WriteLine("Yapici blok calisti");
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            City = city;
         }  
        
        //Biz parametre olarak propertye karşılık gelen parametre ısımlerını verıp sonra da onlari propertylere atarsak o zaman
        //biz property lerimizi Customer class i icinde aslinda globallestirmis oluruz yani artik Customer class i icerisinde
        //yazacagimiz tum methodlarda biz property lere dogrudan ulasiriz ve kullanabiliriz
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public int CustomerNumber { get; set; }


        public void GetInfo()
        {
            Console.WriteLine(FirstName + LastName+this.CustomerNumber);
        }
    }


   
}
