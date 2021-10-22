using MusteriYonetimSistUygulamasi.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusteriYonetimSistUygulamasi.Concret
{
    public class CustomerCheckManager : ICustomerCheckService
    {
       
        //Biz CustomerCheckManager icerisinde Mernis servisine baglanacagiz...
        public bool CheckIfRealPerson(Customer customer)
        {
            return true;//Biz burda dogrulanmis varsayiyoruz
            //Biz Mernis seris baglanti isini gerceklestiremedigimiz icin sorun yasiyor olabiliriz ama halletmis olsa idik
            //Dorguran mernise alttaki gibi baglanmak iyi bir yontem degil cunku Mernis e bagilmi oluyorsun yani Mernis calismasa
            //sistem de calismaz, kod yazamassin, test amacli birsey yapamazsin test yapacagin zaman gercek servise baglanman gerekir
            //Yarin oburgun Mernis degisti baska birsey oldu problem, mernis den vazgecip kendi veritabanini kullansak o da problem
            //Dolayisi ile bir adaptore ihtiyacimiz var yani dis bir servisi sisteme adapte ederken adaptor denilen design pattern
            //kullanilir
            //MernisServiceReferance.KPSPublicSoapClient client = new MernisServiceReferance.KPSPublicSoapClient();
            //Microservislerin implementasyonu icin bir ornek
        }
    }
}
//Customer i check i yontecegimiz CustomerCheckManager burada ICustomerCheckService i implement ediyor
//Starbacks a hic bir sekilde bagimli degiliz tamamen genel bir operasyon yapiyoruz ki daha sonra biz starbacks in 
//talep ettigi bu sistemi baska sirketler de isterse biz dogrudan onlari bu sisteme dahil edebilecegiz yani mevcut kodlara
//dokunmadan sistemimize dahil edebilecegiz...
//Starbacks a hicbirsekilde bagli olmadan sistem yapiyoruz...