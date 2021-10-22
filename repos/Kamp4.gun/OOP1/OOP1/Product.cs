using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1
{   //Property class ları genellikle customer,person,product gibi isimlendirmelerle isimlendirilir!!!!!!!!!!!!!!!!!
    //Bu tip class larda sadece özellik olur başka birşey olmaz. Class lar iki şey için kullanılırdı unutmayalım
    //işte birisi özellik tutan classlardı, diğeri de operasyon tutan yani methodlarımızıt tutan classlardır
    //Bir e-ticaret sitesinin yönetim panelinde yeni bir ürün eklenir,güncellenir,silinir işte bunların
    //hepsine biz CRUD operasyonları diyoruz
    //Otomasyon projelerinde biz veritabanı programlama yaparız genellikle bankacılık,e-ticaret,youtube,kodlama.io bunların
    //hepsi veritabanı programlamadır.Sektörde de tüm projeler 99% bu şekilde çalışır, oyun uygulaması bile olsa
    class Product
    {
        public int Id { get; set; }
        //Bizim ana anahtarimiz primary key id dir yani biz bu urunu digerlerinde id uzerinden ayirt ederiz ve bu id ile
        //veritabaninda armaalarda kullanabiliriz.Bu veriyi anlatan ,ayırt eden Id dir onun için çok önemlidir
        public int CategoryId { get; set; }
        //Id den sonra her zaaman CategoryId yi yazmamız daha iyi olur. Bizim referans anahtarı,foreignkey ikinci sıraya yazılır
        //Ürünün kategorisini belirtmek için kullanırız
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }//Ürün birim fiyatı
        public int UnitsInStock { get; set; }//Ürün stok adedi
    }
    //Bu isimlendirmeler çok önemlidir
    
}
