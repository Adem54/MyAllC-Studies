using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCodeFirstDataAnnotation.Entities
{
    [Table("Orders")]//Sen tablo olarak Orders a karsilik geliyorsun diyoruz...
    //Onunla map edileceksin diyoruz...
  public  class Siparis
    {
        [Column("OrderID")]//Sen beritabaninda OrderID olarak olus demis oluyoruz yoksa biz bunu demezssek gider o Kod
                           //diye olusturur

        //Normal sartlarda bız Id e karşılık gelen property ismimiz ne ise onu eger biz int olarak olusturursak
        //default olarak onu isIdentity yani autoincrement gibi yani otomatik artis olacak sekilde olusturuyor
        //yani defatultta uyguladigi sey [DatabaseGenerated(DatabaseGeneratedOption.Identity)] dur o yuzden eger
        //id nin otomatik artmasini isiyorsak id yi int verip baska hicbirsey vermesek de olur ya da 
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] bunu da yazabiliriz..
        //Ama identity yi otomatik degil ben kendim verecegim dersek o zaman da
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] deriz
        //Veritabaninda default degeri varsa yani hani default diye olusturuluyor ya o zaman da
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)] seklinde veririz

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Kod { get; set; }
       
        [Column("CustomerID")]
        public string MusteriKod { get; set; }

        //Her siparisin bir musterisi olmasi gerekiyordu
        [ForeignKey("MusteriKod")] //Burdaki Musteri porpertisimiz bir foreign keye karsilik geliyor ve bu
         //foreignkeyin degeri de aslinda bizim musteri kodumuzdur
       
        public Musteri Musteri  { get; set; }
       
    }
}
