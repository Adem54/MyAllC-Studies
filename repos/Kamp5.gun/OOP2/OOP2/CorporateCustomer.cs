using System;
using System.Collections.Generic;
using System.Text;

namespace OOP2
{
    class CorporateCustomer:Customer//CorporateCustomer Customer class ini inheritance alarak kendisi de bir Customer olmus oluyor
        //Burda sadece CoroporateCustomer a has property leri giriyoruz
    {
        public int Id { get; set; }
        
        public string CompanyName { get; set; }
        public int TaxNumber { get; set; }

    }
}
