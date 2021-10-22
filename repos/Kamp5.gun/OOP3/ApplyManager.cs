using System;
using System.Collections.Generic;
using System.Text;

namespace OOP3
{//Kredi basvuru operasyonlarinin oldugu bir ApplyManager class i olusturruruz
    class ApplyManager
    {
        // //COOOK ONEMLI!!!!BURAYI IYI YAKALA!K
        //Basvuran bilgilerini degerlendirme ve basvuranin talebine gore onun kredisini hesaplamak isteyebiliriz burda
        //Yani krediye basvuran birisi gelip bizden basvuru konusunda bilgi almak isterse o zaman bu class a ihtiyacimiz olur
        //O zaman bizim bu class ta diger tum class larin hesapla methodunu kullanabilmemiz lazim ki musteri bizden hangi
        //krediyi hesaplamaizii isterse onu hesaplayabilelim ve ona gore basvuru alalim
        //Iste hicbir class a bagimli olmamak icin bagimliliklarimizdan kurtulmak icin  biz burda parametreye bizim tum spesiel
        //class larimizin referansini tutabilen interface i verirksek o zaman diger tum class larin da hesaplama islemini burda 
        //burda yapabiliriz
        //Burda basvuru yapilacak tek bir kredi gerekiyor ondan dolayi parametreye tek ICrediManager yazariz

        //SONRADAN EKLENEBILECEK BIR SENARYO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //YENII BIR SENARYO DUSUNELIM BIZ HER BASVURUDA HEM MUSTERIYE SMS HEMDE KENDI DATABASEIMIZE LOGLAMA YAPALIM...
        //BU DURUMDA PARAMETREYE SADECE ILOGGERSERVICE INTERFACEE YERINE ONU LISTE ICINDE PARAMETREYE YAZARIZ VE FOREACH ILE 
        //DONDEREREK LOGLAMA ISLEMINI FOREACH ICERISINDE YAZARIZ KI PROGRAM.CS TARAFINDA LISTEYE HANGI LOGLAMA CLASS LARI
        //YAZILIRSA ONLAR BIR KERE DE GELMIS OLSUN.......
        //PROGRAM.CS TARAFINDA- 
        // applyManager1.ApplyForCredit(shopkeeperCreditManager, new List<ILoggerService>(){new SmsLoggerService(), new DatabaseLoggerService()});
        //istersek de   List<ILoggerService> loggers=  new List<ILoggerService>(){new SmsLoggerService(), new DatabaseLoggerService}
        //islemini disarda yapip buraya  degisken de atabilirdik..........
        ///



        public void ApplyForCredit(ICrediManager crediManager,ILoggerService loggerService)//Biz Interface i parametre olarak vererek aslinda onu implemente eden
            //tum class larin burada parametre olarak atanabilmesini saglamis olduk ve harika bir sistem kurmus oluyoruz surduru
            //lebilirlik acisindan
        {
            crediManager.Calculate();
            loggerService.Log();
            //DEPENDENCY INJECTION!!!!!!-BURAYI COK IYI ANLA
            //IKINCI BIR INTERFACE I DE BURAYA PARAMETRE OLARAK VEREBILIYORUZ KI HANGI LOGGERSERVICE GONDERILIRSE ONUN LOGLANMASI
            //ICIN BIZ INTERFACE OLARAK YAZARIZ PARAMETREYE CUNKU INTERFACE I DIGER LOGGER SERVICE LER IMPLEMENT ETTIGI ICIN ARTIK
            //INTERFACE ONLARIN REFERANSINI TUTABILIYOR VE BIZ DE IKINCI BIR PARAMETRE OLARAK ILOGGERSERVICE INTERFACEIMIZI VERINCE
            //ARTIK LOGLAMA ISLEMINI DE HANGI LOGGER SERVICI SECERSEK ONA YAPABILIYOR OLACAGIZ!!!!!!!
            //BIZIM BIRDEN FAZLA INTERFACE I PARAMETRE DE KULLANMAMMIZ AASLINDA DEPENDENCY INJECTION DEMEKTIR......YANI BU METHODUN
            //KULLANACAGI KREDI TURUNUN NE OLACAGINI VE LOGLAMA TURUNUN NE OLACAGINI ENJEKTE EDIYORUZ
            //Basvuru islemlerimizde hangi  kredi oldugu hangi loglama islemi olduguna dair bilgi yok dikkat edelim orda interface
            //lerimiz var yani sadece soyut halleri var somut hallerini biz enjekte ediyoruz. Interface lerimiz araciligi ile inter
            //facelerimiz onlarin referansini tutabildigi icin interfacelerimiz araciligi ile biz tum kredi turlerimiz veya tum log
            //turlerimize bu operasyonda kullanabiliyoruz hangisini istersek onu kullanabiliyoruz
        }
        //COOOK ONEMLI!!!!BURAYI IYI YAKALA!K
        //Simdi gidip Program class inda hangi class ta istersek onda credi basvurusu class indan nesne olusturup sonra 
        //ondan ApplyManager in ApplyForCredit methodunda gelip istedigmiz class i parametre olarak verebiliriz 

       //Musteri kendine uyan kredi tiplerini gormek ister banka gorevlisi de musterinin bilgilrine veya ozelliklerine, durumuna gore
       //hangi krediler ona uyduguna bakar ve o musteriye 2 tip kredi nin uydugunu farkeder ve ikisini birden hesaplayip getirmek ister
        //100 lerce kredi cesidi var banka memuru onlardan hangilerini ve kactane sececegi belli degil
        public void KrediOnBilgilendirmesi(List<ICrediManager> credits)
            //Listenin herbir kredinin hesabini yapabilmesi icin parametreye liste gonderelim
            //Burda hic gelmeme ihtimali de var 100 tane gelme ihtimali de var o zaman bunu biz
            //List class i yani generic List yani dizi yerine kullandigimiz List ile parametreye veririz
            //Veri turu ise IKrediManager olacak cunku bu veri turunu tum kredi tipi class larimiz taniyor.....cunku bu veri turu
            //tum kredi tipi class larin referansini tutabiliyor
        {
            //Biz parametreye List verdigimize gore  bu Listi alabilmek icin foreach ya da for ile dondurmem lazim
            foreach (var credit in credits)
            {
                credit.Calculate();

            }
        
        
        }


        //Krediyi hesaplayalim bir once
    }
}
