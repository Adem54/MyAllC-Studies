using System;


namespace DependencyInjection
{
    public class Araba:ITasit
    {
    
        public void GazVer()
        {
            Console.WriteLine("Araba gaz veriyor");
        }
        public void FrenYap()
        {
            Console.WriteLine("Araba fren yapiyor");
        }
        public void SagaSinyal()
        {
            Console.WriteLine("Araba saga sinyal veriyor");
        }
        public void SolaSinyal()
        {
            Console.WriteLine("Araba sola sinyal veriyor");
        }
    }
}

//DEPENDENCY INJECTION
//Dependency Injection’ı özetle anlatmak gerekirse; bağımlılık oluşturacak parçaların ayrılıp, bunların dışardan verilmesiyle
//sistem içerisindeki bağımlılığı minimize etme işlemidir. EEee yani!
//Yani, temel olarak oluşturacağınız bir sınıf içerisinde başka bir sınıfın nesnesini kullanacaksanız new anahtar
//sözcüğüyle oluşturmamanız gerektiğini söyleyen bir yaklaşımdır. Gereken nesnenin ya Constructor’dan ya da Setter
//metoduyla parametre olarak alınması gerektiğini vurgulamaktadır. Böylece iki sınıfı birbirinden izole etmiş olduğumuzu
//savunmaktadır. Ha doğru mudur?, dibine kadar doğrudur…
//Daha da özetlememiz gerekirse yazılımı oluşturan yapılar kaçınılmaz olarak birbirleri ile ilişkilidir.
//Lakin bu ilişkinin bir bağa ve sınırlandırmaya sebep olmaması için mümkün mertebe ilişkiyi gevşek tutmak önemlidir.
//Biz buna Loosely Coupled yani Gevşek Bağlılık diyoruz.
//Bundan dolayı yazılımı oluşturan yapıların birbirleri ile olan sıkı bağ azalacağı için uygulamaya yeni özellikler
//eklenip çıkartılabilmesi kolay hale gelecektir. Bu durumu şöyle örneklendirelim.
//Elimizde “A” ve “B” sınıfı olsun. “A” sınıfında “B” nesnesi üretildiğini düşünün. Yazımızın devamında da
//örneklendireceğimiz gibi “A” sınıfı “B” sınıfına bağlı hale gelmiştir. Gün geldi “B” nesnesinde bir değişiklik
//olduğu zaman mecbur gidip “A” sınıfında da bu değişiklik üzerine çalışma yapmamız gerekecektir. Tamam,
//eğer burada konuştuğumuz gibi projeniz iki sınıftan ibaretse hiç Dependency Injection mevzusuna girmeden
//gidip “A” sınıfında değişikliği yapmanız mantıklıdır. Ama yüzlerce class’lardan oluşan bir proje için bunu
//denemenizi pek tavsiye etmem. Eee, peki ne yapacağız? diye sorarsanız eğer, “A” nın “B” ye olan bağımlılığını
//minumuma indirgeyeceğiz. Tabi bunun nasıl yapıldığını yazının devamında irdeleyeceğiz.
//İşte bu tarz bir durumda Dependency Injection tekniğini uygulayarak uygulama içerisinde değiştirilmesi,
//müdahale edilmesi gereken yerler minumuma inecektir.
//Dependency Injection, bağımlılıkları soyutlamak demektir.
//Dependency Injection’ın teferruatlarına girmeden önce dikkat etmeniz gereken husus şudur ki;
//Dependency Injection çoğu zaman Dependency Inversion ile karıştırılır. Fakat Dependency Inversion problem
//çözmeye yarayan bir prensip iken Dependency Injection ise bu prensibi uygulayan bir Design Pattern’dir.
//Şimdi Dependency Injection’ın tasarımını uygulama durumlarını konuşalım…

//DI, aşağıdaki iki teknikle uygulanabilmektedir.
//Constructor Injection(Constructor Based Dependecy Injection)
//Setter Injection(Setter Based Dependency Injection)
//Sizlere iki yöntemle örnek durumlarıda göstereceğim. Şimdi DI desenini uygulayabileceğimiz durumları pratik olarak inceleyelim.
