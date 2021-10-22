using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCodeFirstDataAnnotation.Entities
{
    [ComplexType]
    public class MusteriSiparisDTO
    {   //Bazen bu sekilde Musteri ve Siparisi join edip bu sekilde DTO olustururuz
        //Musterinin ve siparisin ayni anda gozukebilmesi icin komplekst tipler olustururuz bazen
        //DTO yani join ile birlestirdigimiz Dto nesnelerimiz de olusturdugumuz tiplere komplex tipler deriz ve 
        //bu DTO nunda veritabaninda olusmamasi gerekiyor bunun icinde yine veritabanda olusmasin diye
        //MusteriSiparisDTO classimizin ustune [ComplexType] attributunu koyariz...
        public int   CustomerID { get; set; }
        public int OrderID { get; set; }
    }
}
