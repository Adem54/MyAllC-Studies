using System;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SqlServer sqlServer = new SqlServer();
            sqlServer.Add();
            Mysql mysql = new Mysql();
            mysql.Add();

            Console.ReadLine();
        }
    }


    class Database
    {
        public virtual void Add()
        {
            Console.WriteLine("Added by default");        }
        public virtual void Update()
        {
            Console.WriteLine("Updated by default");
        }
    }

    class SqlServer : Database//Base class ımızı Database dir yani inheritance alınan class
    {
        //Bizim database kısmına yazdığımız kod tüm veritabanlarında geçerli dir ama sql server ile
        //çalışırken o zaman daha farklı kod yazmak gerekebiliyor ve database class ı içerisinde yazacağımız
        //kodlar SqlServer class ı içerisinde daha farklı yazmak gerekebiliyor
        public override void Add()//override yazar ve tab tuşun a basarsak o zaman public override void Add() şeklinde gelecektir
        {

            Console.WriteLine("Added by SqlServer");//biz basis ile Add eklyeceğimize onun yerine Console.WriteLine ile kendimiz birşeyler yazacağız
          //  base.Add();//base in Add ini çalıştır yani base dediği babasının base ini çalıştırıyor yani Database class ının
          //  Add ini  çalıştırıyor aslıında
        
        } //Sql de virtual i override ettiğimiz için genel Database deki yerine Sql e yazdığımızı okuyor yani biz kendi direk
          //sql deki kodu çalıştırmak istediğimiz zaman bu şekilde Database deki kodu ezmiş oluyoruz ama hem Database clas
          //s ındaki hemde SqlServer gibi class larımızdaki kodlar çalışmasını istersek o zaman hem basis.Add çalışır hemde
          //SqlServer a has yazdığımz kod çalışır

    }

    class Mysql:Database
    {

    }
}
