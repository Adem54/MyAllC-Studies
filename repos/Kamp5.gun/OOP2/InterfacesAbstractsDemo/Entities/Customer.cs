using System;

namespace MusteriYonetimSistUygulamasi
{
   public class Customer:IEntity
    {
        public int Id  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NatioanalityId { get; set; }
    }
}


//Bu tarz properties leri yazdigimiz class lari biz Entities yani varliklar adi verilen klasore atabiliriz