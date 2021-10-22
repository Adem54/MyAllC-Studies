
using MusteriYonetimSistUygulamasi.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygulamasi.Concret
{
    public class NeroCustomerManager:BaseCustomerManager
    {
       
    }
}
//Nero Customer larini yonetmek icin yazilmis bir nesnedir
//ONEMLI!!!!!!
//NeroCustomerManager da bir BaseCustomerService dir ve BaseCustomerService yi inherit ediyor BaseCustomerService de
//ICustomerService interface inii implemente etmisti bu sekilde NeroCustomerManager dolayli yonden interface deki Save
//methodunu da miras almis oldu yani. Bu sekilde hem BaseCustomerManager class i icindeeki elemanlara ulasacak ayni zamanda
//BaseCustomerManager clasinin implement ettigi ICustomerManager interface inin de referansini kullanabilecek 
//
