using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCodeFirstDataAnnotation.Entities
{
    //Tablo olarak da Customers olarak olustursun istiyorsak bu sekilde yazariz 
    //using System.ComponentModel.DataAnnotations.Schema; burdan geliyor
    [Table("Customers")]
   public class Musteri
    {
        //[Key] using System.ComponentModel.DataAnnotations; burdan geliyor
        [Key] //Bu bizim icin bir key olacak dataannotaion in key attributunden yararlaniriz
        //Eğer sadece tek bir integer alan Key olarak işaretlenmişse bu alan aynı zamanda identity olarak da belirlenir. yani sayı otomatik olarak üretilir. Birden fazla alanın identity olarak işaretlendiği key yapılarında bu alanlardan herhangi biri identity olarak işaretlenmez.
        //Biz burda Id yi Kod isminde tutuyoruz ama veritabaninda bunun ismini ingilizce tutmak istiyorum mesela o zaman
        //Northwind gibi olusturmak istiyoruz mesela kendimiz veritabani kolon isimlerini ve de veritabani ve kolonlari da 
        //tamamen biz olusturmus olacagiz kod tarafinda once kod yazarak,entityframework mantiginda
        [Column("CustomerID")]
        [MaxLength(5)]
        public string Kod { get; set; }

        [Required] //Bizim icin zorunlu bir alan olmasini istersek boyle yapariz ama bunlar bestpractise degil unutmayalim
                   //Bu da dataannotaiondan geliyor..VAlidation icin kullaniyoruz
        [Column("ContactName")]
        [MaxLength(50)]
        [ConcurrencyCheck]//Bu da bizim operasyonlarimizin biri ile update islemi gerceklestirirken ayni adna iki update 
        //isleminin yapilmasi bunlarin birbiri ile cakismansina sebep olabiliyor dolayisi ile bunun engellenemsi icin
        //ConcurrencyCheck kullaniyoruz..
        //ConcurrencyCheck sadece kolonu garanti altina alirken TimeStamp satiri garanti altina aliyor
        //Yani birden fazla kolonun icinde bulundugu satiri garanti altina aliyor.Yani timestampt biraz daha advance dir
       //Veritabanina normal kolonlarin yanisira birde oraya timestampt kolonu olusturuyor ve bu timestampt 
       //bizim sorgularimizda bir tane satir icin uniq deger tutuyor 
       
        public string Ad { get; set; }
        [Required]
        [Column("CompanyName")]
        [MaxLength(50)]
        public string Sirket { get; set; }
        
        [Column("Country")]
        [MaxLength(50)]
        public string Ulke { get; set; }
       
        [Column("City")]
      
        public string Sehir { get; set; }

        //Peki mesela bir tane property miz olsa veritabaninda olmasini istemedigimiz yani orda olusmasini 
        //istemedigimiz bir propertysimize datannotations da [NotMapped] yazarak veritabaninda olusmasini engelleyebiliriz
        [NotMapped]
        public string UlkeVeSehir { get; set; }

        //TimeStamp ler byte[] olarak tutuluyor
        [Timestamp]
        public byte[] TimeStamp { get; set; }

        //Her musterinin birden fazla siparisi olabilir
      
        List<Siparis> Siparisler { get; set; }
    }
}
//Fluent Api ile daha advance seyler yapabiliyoruz daha da ileri goturebiliyoruz ve altyapi olarak biraz daha kurumsal
//mimarilere uygundur