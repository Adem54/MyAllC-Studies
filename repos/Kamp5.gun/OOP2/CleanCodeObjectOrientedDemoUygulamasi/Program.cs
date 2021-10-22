using CleanCodeObjectOrientedDemoUygulamasi.Adapter;
using CleanCodeObjectOrientedDemoUygulamasi.Entities;
using CleanCodeObjectOrientedDemoUygulamasi.Managers;
using CleanCodeObjectOrientedDemoUygulamasi.Services;
using System;

namespace CleanCodeObjectOrientedDemoUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {

            Product product = new Product();
            product.ProductName = "TV";
            product.UnitPrice = 1000 ;
            Customer studentClient = new Student();
            studentClient.FirstName = "OgrenciTahir";
            studentClient.LastName = "Caliskan";
            Customer usualClient = new UsualCustomer();
            usualClient.FirstName = "Adem";
            usualClient.LastName = "Erbas";
            Customer teacherClient = new Teacher();
            teacherClient.FirstName = "AhmetOgretmen";
            teacherClient.LastName = "Derin";
            

            CurrencyRateDto currenyRateDto = new CurrencyRateDto();
            currenyRateDto.Currency = 2;
            IBankService bankService = new FakeBankService();
            UsualClientManager usualClientManager = new UsualClientManager(bankService);
            usualClientManager.SaleTL(usualClient, product);
            usualClientManager.SaleWithOtherCurrency(usualClient, product, currenyRateDto);
            Console.WriteLine("-------------------------------------------------------");
            StudentManager studentClientManager = new StudentManager(bankService);
            studentClientManager.SaleTL(studentClient, product);
            studentClientManager.SaleWithOtherCurrency(studentClient, product, currenyRateDto);

            //Sistemimize bir de disardan yeni bir talep aldik ve o talepe sistemimiz ne kadar uyumlu onu 
            //test etmis olduk burda

            Console.WriteLine("Teacher icin satis");
            TeacherSaleManager teacherClientManager = new TeacherSaleManager(bankService);
            teacherClientManager.SaleTL(studentClient, product);
            teacherClientManager.SaleWithOtherCurrency(studentClient, product, currenyRateDto);





            Console.ReadLine();
        }
    }
}
