using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CustomerManager customerManager = new CustomerManager();
            customerManager.Add();

            //Propert Ekleme Yöntemi1
            //Biz property e eşittir diyerek yeni bir değer atadığımız zaman property yi yazdığımız Customer class ında property
            //leri yazarken kullandığımız set işlemi çalışıyor yani biz propertye değer atarken aslında set ediyoruz yani kuruyoruz
            //yani değeri veriyoruz
            //customer.FirstName diyerek veriyi aldığımızda ise Customer clasındaki properyleri oluştrduğumuzda yazdığımız get bloğu burda
            //çalışıyor çünkü veriyi alıyoruz burda yani veriyi okuyoruz
            Customer customer = new Customer();
            customer.Id = 12;
            customer.FirstName = "Adem";
            customer.LastName = "Erbas";
            customer.City = "Skien";

            Console.WriteLine(customer.FirstName + customer.LastName);
            //Propert Ekleme Yöntemi2
            Customer customer1 = new Customer() {Id=24, FirstName="Engin", LastName="Demiroğ",City="Ankara" };
            Console.WriteLine(customer1.FirstName + customer1.LastName);


        }
    }
}

//1)Class ların öncelikli özelliği projemizde yazacağımız kodları kategorize edip yaptıkları işlere göre
//gruplayarak işlerimizi daha düzenli temiz kod yazmaktır ve özellikle de sürdürülebilirliği sağlamaktır
//sonradan yapılması gereken değişiklikleri projemize daha kolay adapte edebilmektir
//2)Class lar property tutabilir. Property bir müşteri veya çalışan vs ın özellikleri tutmak için kullandığımız nesnedir
//yani onun id,name,lastname vs gibi ona ait bizim projede kullanmamız gereken bilgileri aslında özellikleridir
//Yani property veritabanlarındaki Customer, Employee ile ilgili verileri biz bu class aracılığı ile property olarak tutabiliyoruz
