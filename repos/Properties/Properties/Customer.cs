using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{

    class Customer
    {
       // public string FirstName;=>field tanımlama-değişken tanımlama
       
        //Property Tanımalama
        public int Id{ get; set; }//Burda set bloğu biz ne zaamanki bu propertye yeni bir veri atadık veya verisini değiştirdik
                                  //o zaman set bloğu çalışacaktır ama ne zaman ki biz propertynin değerin okuduk veya değerini
                                  //döndürdük o zamanda çalışan get bloğu olacaktır

        private string _firstName;    //Örneğin biz bir müşteri isminin başına Mr getirmek istersek eğer set kullanmasa idik gidip o müşterinin ismiinin geçtiği
        //heryeri tek tek değiştirmek zorunda kalacaktık
        //Bir field yani değişken üzerinde set veya get etmek istersek o zaman olayı bu şekilde yapmalıyız işte bu yapılan işlem ise encapsulation deniyor
        public string FirstName {
            get { return "Mr. " + _firstName; }
            
           set
            {
                _firstName = value;
            }
                }
        public string LastName { get; set; }
        public string City { get; set; }
        //Burda doğrudan değişken olarak değilde özellik yani property olarak tanımalamanın ne gibi bir farkı var ona bakalım
        ///ÖNEMLİ!!!!!!!!!!!!
        //Örneğin biz bir müşteri isminin başına Mr getirmek istersek eğer set kullanmasa idik gidip o müşterinin ismiinin geçtiği
        //heryeri tek tek değiştirmek zorunda kalacaktık
    }
}
