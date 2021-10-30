using System;

namespace SpecificationPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //Altyapımızı oluştururken öncelikle şartname niteliğinde bir interface hazırlamalıyız.
public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T candidate);
    }
    //Şartnamemizde, bu şartnameyi uygulayan sınıfların tipinden bir generic “T” parametresi verilmiştir.
    //Bu sayede şartname tipi dışarıdan alınabilir şekilde genelleştirilmiştir.

    //ISpecification<T> tipine T parametresi yerine vereceğimiz ve iş nesnesi olarak kullanacağımız ürün tipini, adını Product olacak şekilde belirliyoruz.
    //public partial class Product
    //{
    //    public decimal Stock { get; set; }
    //}
    //Artık bu tipimize bir iş kuralı belirlememiz gerekmektedir. İş kuralımızı kısaca stok miktarının kritik olduğu durumu gözetecek şeklide belirleyebiliriz. Stok miktarı 50’nin altına düşerse şartımız çalışacaktır.
    public class IsCriticalStock : ISpecification<Product>
    {
        public bool IsSatisfiedBy(Product product)
        {
            return product.Stock < 50;
        }
    }

    //Şartnameyi kabul eden bir tip olarak IsCriticalStok isimli sınıf oluşturduk. Artık iş kuralını bünyesinde barındıran bu sınıfımızı Product tipine tanıtabiliriz. Product tipimizi yeniden tasarlayacak olursak;

    public partial class Product
    {
        private readonly IsCriticalStock isCriticalStock;

        public Product()
        {
            isCriticalStock = new IsCriticalStock();
        }

        public decimal Stock { get; set; }

        public bool IsStockEnough()
        {
            return isCriticalStock.IsSatisfiedBy(this);
        }
    }
    //Bu şekilde iş kuralımızı Product tipine geçirmiş oluruz. Kodun okunabilirliğini arttırmak için Product sınıfını parçalı şeklide “Partial” tanımlayabiliriz.
}
