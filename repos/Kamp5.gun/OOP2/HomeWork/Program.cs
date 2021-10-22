using HomeWork.Concrete;
using HomeWork.Entities;
using System;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Person person1 = new Person() {Id=1234, FirstName="Ahmet", LastName="Kaya", DateOfBirth=new DateTime(1988, 7, 4), 
                IdendifyNo= "987654321" };


            //DIKKAT EDELIMMM BIZZ CLASS IN PARANTEZ ICINDE BASKA BIR VERI VERME ISLEMINI CONSTRUCTOR LARDA PARAMETREYE VERI
            //VERINCE YAPABILIYORDUKK...
            PersonManager personManager = new PersonManager(new PersonCheckManager());
            personManager.Add(person1);
            personManager.Delete(person1);
            personManager.Update(person1);


            Console.WriteLine("----------------------------------------------");

            PlayStation playStation = new PlayStation();
            GameOfThrones gameOfThrones = new GameOfThrones();
            SuperRacing superRacing = new SuperRacing();
            GameSellerManager gameSellerManager = new GameSellerManager(
                new KampanyaCheckManager(), new Kampanya1()
                ) ;
            gameSellerManager.Sell(gameOfThrones, person1);

            Console.WriteLine("...................................................");
            KampanyaManager kampanyaManager = new KampanyaManager();
            kampanyaManager.AddKampanya();
            kampanyaManager.DeleteKapmanya();
            kampanyaManager.UpdateKampanya();



            Console.ReadLine();
        }
    }
   
}









//Bir oyun yazmak istiyorsunuz. Bu yazılım için backend kodlarını C# ile geliştirmeyi planlıyoruz.
//Yeni üye, satış ve kampanya yönetimi yapılması isteniyor. Nesnelere ait özellikleri istediğiniz gibi verebilirsiniz.
//Burada amaç yazdığınız kodun kalitesidir. Ödevde gereksinimleri tam anlamadığınız durum benim için önemli değil,
//kendinize göre mantık geliştirebilirsiniz. Dediğim gibi kod kalitesiyle ilgileniyoruz şu an :)



//Gereksinimler

//1.     Oyuncuların sisteme kayıt olabileceği, bilgilerini güncelleyebileceği, kayıtlarını silebileceği
//bir ortamı simule ediniz. Müşteri bilgilerinin doğruluğunu e-devlet sistemlerini kullanarak doğrulama yapmak istiyoruz.
//(E-devlet sistemlerinde doğrulama TcNo, Ad, Soyad, DoğumYılı bilgileriyle yapılır. Bunu yapacak servisi simule etmeniz yeterlidir.)

//2.Oyun satışı yapılabilecek satış ortamını simule ediniz.( Yapılan satışlar oyuncu ile ilişkilendirilmelidir.
//Oyuncunun parametre olarak metotta olmasını kastediyorum.)

//3.Sisteme yeni kampanya girişi, kampanyanın silinmesi ve güncellenmesi imkanlarını simule ediniz.

//4. Satışlarda kampanya entegrasyonunu simule ediniz. Her satis yaparken urunun kampanya ya dahil olup olmadigini cek et
//eger kampanyaya dahilse kampanya kapsaminda ne kadar indirim kazandigini belirt , kampanya yoksa indirim kazanamadigini belirt

//5.     Ödevinizi Github’a yükleyiniz. Github linkinizi paylaşınız.

//6. Diğer arkadaşlarınınız Github kodlarını inceleyiniz. Ona yıldız vermeyi unutmayınız :)