using System;
using System.Collections.Generic;

namespace SpecificationPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kriterlerin kullanımı da son derece kolay olacaktır.
            var result1 = CustomerAnalyzer.GetCustomerBySpecification(new CustomerCitySpecification("İstanbul"));
            var result2 = CustomerAnalyzer.GetCustomerBySpecification(new CustomerSalarySpecification(1000, 5000));
            //Bu sayede CustomerAnalyzer sınıfı için söz konusu olabilecek ne kadar özelleştirilmiş operasyon varsa kaldırılmış ve daha da önemlisi bu operasyonları sisteme dışarıdan öğretebilir hale getirmiş oluyoruz(Bir nevi plug-in tabanlı bir ortama doğru ilerlediğimizi ifade edebiliriz) Yaptığımız örnek farklı ihtiyaçlar için de değerlendirilebilir. Örneğin Domain Driven Design içerisinde Entity'lerin belirli kriterlere göre doğrulanması gerektiği hallerde ele alınabilir. Bu yaklaşım biraz daha profesyonel olarak ele alındığında ortaya mimari kalıplar arasında yer alan Specification Design Pattern çıkmaktadır.

            //C# tarafında generic mimarinin ve Interface kullanımının da işe katılması halinde çözüm daha da zenginleştirilebilir. Nitekim söz konusu örnekte bazı handikaplar vardır. Çözüm sadece Customer tipi için söz konusudur. T türünden bir Entity tipi için benzer senaryo inşa edilmek istenebilir. Bu durumda C#'ın generic nimetlerinden de yararlanabiliriz. Hatta şartname bir arayüz(Interface) olarak da tasarlanabilir. Nitekim bu arayüzden türetmeler yapılarak kompozit şartnamelerin hazırlanması(and, or gibi mantıksal birleştirme yaklaşımlarını içeren) ve zincir şeklinde metod kullanımlarına imkan tanınarak aynı entity için ardışıl kriterlerin entegre edilmesi mümkün hale getirilebilir(Bu karmaşık cümleyi daha iyi anlamak için wikipedia adresine bakmanızı öneririm)
            Console.WriteLine("Hello World!");
        }
    }
    //Şu sıralar üzerinde çalışmakta olduğumuz bir projede karşılaştığımız bir sorun var. Belli bir Domain içerisinde yer alan bazı varlıkların(Entity türleri diyelim) çeşitli kriterlere uyanlarının liste olarak çekilmesi gerekiyor. Senaryonun ilginçleştiği kısım ise farklı Entity tipleri için zaman içerisinde farklı kriterlerin de sisteme dahil edilmek istenebileceği. Bu sayede veri kümesi üzerinde çeşitli araştırma senaryolarını denemek  de mümkün hale geliyor. Bir başka deyişle aklımıza geldikçe yeni bir kriteri(örneğin bir filtreleme ölçütünü) tanımlayıp iistediğimiz Entity kümeleri üzerinde kullanmak istiyoruz.
    //Konu bir süre sonra sıkıcı hale gelmeye başlayınca pek tabii bilinen yazılım kalıpları ile çözülebilir mi diye de araştırmaya başladım(Nasıl araştırdım derseniz yandaki şekle bakabilirsiniz) Aklıma gelen bazı çözümler vardı ve nihayet sonunda kendimi Specification tasarım kalıbını araştırırken buldum. Wikipedia' daki benim için karmaşık olan örnek ve Master Martin Fowler'ın konu ile ilgili yazısını takiben basit bir kod parçası araştırarak geçirdiğim bunaltıcı saatlerden sonra konuyu kendimce yazıya dökerek açıklayabilirim diye düşündüm.

    //  İlk olarak sorunu masaya yatırmaya çalışalım.Elimizde aşağıdaki gibi bir sınıf olduğunu düşünelim. Bu sınıf yardımı ile belli bir domain içerisindeki müşterileri temsil ettiğimizi varsayabiliriz.
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Fullname { get; set; }
        public decimal Salary { get; set; }
        public string City { get; set; }
    }
    //Kuvvetle muhtemel müşteri bilgileri bir veri kaynağından beslenecektir. Burada sadece müşteri kümesini temsil etmesi açısından eklenmiştir. Şimdi geliştirmekte olduğumuz uygulamanın şöyle bir ihtiyacı olduğunu düşünelim; Istanbul'da yaşayan müşterileri görmek istiyoruz. Aslında şehrin adının çok önemi yok. Ankara'da ikamet eden müşterilerimizi de görmek isteyebiliriz. Ayrıca maaşı belli bir değer aralığında olanları da görmek isteyebiliriz. Kısacası belirli kriterlere uyan müşteri kümelerini çekmek istediğimiz operasyonlarımız olduğunu düşünelim. Bu durumda aşağıdakine benzer bir sınıf tasarlamak aklımıza gelecek ilk çözümlerden birisidir.
    //public class CustomerAnalyzer
    //{
    //    public List<Customer> GetCustomerByCity(string city)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public List<Customer> GetCustomerNameContains(string letter)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //(Örnek kod parçası sadece gösterim amacıyla yazıldığından metod içlerinde bilinçli olarak NotImplementedException istisnası fırlatılmıştır)

    //Aslında gayet anlaşılır görünüyor öyle değil mi? Fakat duayenlere göre müşterilerimizi araştırmak adına yeni bir fonksiyonellik söz konusu olursa CustomerAnalyzer sınıfına yeni bir metod daha eklememiz gerekecektir.Oysa ki, kalıp olarak daha efektif bir çözüm olmalı.Öncelikle CustomerAnalyzer sınıfına ait karmaşıklığı ortadan kaldırmamız ve daha sonradan eklenebilecek filtreleme kriterleri için gevşek bağlı(Loosely Coupled) bir yapı tasarlamaya çalışmalıyız.Bunu gerçekleştirmek için işe çeşitli tipte kriterler için genel bir şablon tanımlayarak başlayabiliriz.Aşağıdaki kod parçasında yer alan CustomerSpecification sınıfı bu amaçla tasarlanmıştır.
    public abstract class CustomerSpecification
    {
        public abstract bool IsSatisfiedBy(Customer customer);
    }

    public static class CustomerAnalyzer
    {
        // Bu Customer listesinin bir şekilde bir yerlerden dolduğunu düşünelim
        private static List<Customer> customers = new List<Customer>();

        //Burda GetCustomerBySpecification methodu CustomerSpecification yani bir kriter almaktadir...
        //Söz konusu kriter CustomerSpecification tipinden türeyen bir sınıf örneğidir. M
        public static List<Customer> GetCustomerBySpecification(CustomerSpecification spec)
        //Bura uygulanirken bu CustomerSpecification yerine CustomerCitySpecification ya da CustomerSalarySpecification koyabiliriz


        {
            foreach (var customer in customers)
            {
                if (spec.IsSatisfiedBy(customer))
                    //Metod içerisinde bu kritere uyan müşterilerin listeye eklenerek döndürülmesi işlemi söz konusudur(LINQ-Language INtegrated Query tarafında da buna benzer yapılar olduğu mutlaka aklınıza gelmiştir. Orada da benzer prensiplerin uygulandığını söyleyebiliriz)
                    customers.Add(customer);
            }

            return customers;
        }
    }
    //CustomerSpecification isimli abstract sınıf tek bir metod içermektedir. IsSatisfiedBy(ki bu ismi bu desenin anlatıldığı kaynaklarda sıklıkla görmekteyiz) metodunun en önemli özelliği geriye bool değer döndürüp parametre olarak Customer tipinden bir değişken almasıdır. Bu sınıf tahmin edeceğiniz üzere yeni bir şartname için gerekli taban arayüzü(her ne kadar henüz bir interface olmasa da) tanımlamaktadır. Yani müşteri kümesine uygulanacak herhangi bir filtre için bu sınıftan türeyen bir tipin tasarlanması yeterlidir. Bu anlamda CustomerAnalyzer sınıfının yapısı değişmiştir. Dikkat edileceği üzere GetCustomerBySpecification metodu bir kriter almaktadır. Söz konusu kriter CustomerSpecification tipinden türeyen bir sınıf örneğidir. Metod içerisinde bu kritere uyan müşterilerin listeye eklenerek döndürülmesi işlemi söz konusudur(LINQ-Language INtegrated Query tarafında da buna benzer yapılar olduğu mutlaka aklınıza gelmiştir. Orada da benzer prensiplerin uygulandığını söyleyebiliriz)

    //Şimdi yeni bir kriter eklemek istediğimizde tek yapmamız gereken yeni bir şartname hazırlamak ve bunu CustomerAnalyzer tipinde ele almaktır. Örneğin belirli bir şehirde yaşayan müşterilerin tespiti için aşağıdaki gibi bir şartname hazırlanır.

    public class CustomerCitySpecification
    : CustomerSpecification
    {
        private string _city;

        public CustomerCitySpecification(string city)
        {
            _city = city;
        }
        public override bool IsSatisfiedBy(Customer customer)
        {
            return customer.City.ToUpper() == _city.ToUpper();
        }
    }

    //Maaşı belirli bir değer aralığında olan müşterileri mi almak istiyoruz? O zaman yeni bir şartname
    //hazırlayarak ilerleyebiliriz. 

    public class CustomerSalarySpecification
    : CustomerSpecification
    {
        private decimal _minimum;
        private decimal _maximum;
        public CustomerSalarySpecification(decimal minimum, decimal maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }
        public override bool IsSatisfiedBy(Customer customer)
        {
            return (customer.Salary >= _minimum && customer.Salary <= _maximum);
        }
    }
}
