using System;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Matematik matematik = new Matematik();

            Console.WriteLine(matematik.Bol(20, 0));
            //Programci burda hata durumunu kontrol da edebilir, unutmus da olabilir
            //Ornegin birisi payda kismina 0 verdi yani 2.parametreye 0 verdi o zaman ortaya bir hata cikacaktir
            //Uygulama ne yapacagini bilemiyor, bir anda uygualama kapanabilir bunlar biz telefonumuzla ugrasirken
            //de olabilir iste bu durum bir hata ortaya cikmistir ve uygulama ne yapacagini bilemiyordur
            //Bizim bu tarz olaylari kontrol altina almaliyiz..ne ile try-catch ile

            //TRY-CATCH IMIZ CALISIRKEN
            //Biz matematikte Bol methodunda try-cathc yazdik ve biz methodu parametre atayinca ne oluyor direk
            //method methodun yazildigi yer calisiyor ama sonucu ne zman veriyor methodun tamami calisinca dolayisi ile
            //method icinde ein son finally calisiyor console icinde mesaj i  yaziyor finally bittikten sonra
            //artik Matematik.Bol methodunun try icinde return un dondergi degeri console.writeLine araciligi ile
            //gorebiliyoruz.....
            //
            //CATCH LERDE TAKILAN YERLERI F11 ILE GECEBBILIRIZ
            //Uygulamamiz catch lerin herhangi birinde takildigi zaman uygulamanin yasam dongusu degisecegi icin
            //catch lerde calistigi zaman Finally calismayacaktir...Ama throw yerine biz return yazsa idik 
            //ne yapardi, o zaman da return yazdigimiz yerde yani cathc de, orda uygulamayi kirar ve dogrudan finallyye
            //gecerdi....Ama throw da oyle olmuyor.Throw uygulamanin yasam dongusunu degisitiyor....
        }
    }

    public class Matematik
    {
        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }

        public decimal Bol(int sayi1, int sayi2)
        {
            try
            {//Yapilmak istenilen is try icine yazilir.Try basarili bir sekilde calisirsa catch calismaz ama
                //try icindeki kodumuzda bir problem cikarsa catch calisacaktir
                return (sayi1 / sayi2);
            }
            catch (DivideByZeroException)
            {//Yapmak istedigim sey hata verirse catch calisir

                Console.WriteLine("Catch calisti ve bir hata olustu");
                //Biz donus deger i decimal olarak yazdik methodda o nun icin catcch blogunda da birsey return etmeliyiz
                //  return 0;//Simdilik 0 return edelim...
                throw new DivideByZeroException("payda 0 olamaz!");
                //Biz bu sekilde kendi hatamizi firlatabiliriz ve kendi mesajimizi da yazabiliriz...
                //Bu hata firlatma isini biz programci icin yazariz..
                //KULLANICIDAN GELEN DEGERLERE GORE OLUSABILECEK HATALAR.....
                //Bir uygulamada bircok hata olabilir bizim ongoremedgimiz bizim kontrol edemeyecegimiz ancak biz
                //kullanicinin gonderdigi degerlere gore olayi yorumlayip ongorduklerimizi hata gruplarina ayiririz,
                //try-catch ile yaptigimiz gibi.Kisacasi biz hata ongordugumuz yerler icin de farkli hata donusleri 
                //yapabiliriz..
                //Peki yine hata verdiyse ne olacak,yani uygulama nerde kontrol altina alinacak.Aslinda genellikle
                //projemizde yaptigmiz katmanli mimari de,is katmaninda bu try-catch, hata yonetimiz olustururuz
                //onu siniflandiririz ve anlamli bir hata dondururuz,firlatiriz yani.Arayuzde artik kullanici ne yapmak
                //istiyorsa,arayuzde programci onu nasil gostermek istiyorsa oyle gosterir.Yani en son handle edecegi
                //yani kontrol altina alacagi, en son kontrol edecegi yer bunlarin arayuzu oluyor...Yani biz aslinda
                //burda hatayi mantikli bir duruma getirmeye calisiyoruz...
                //BIRDEN FAZLA CATCH BLOGUMUZ OLABILIR!!!
                // catch (Exception) burdaki (Exception) tum hata siniflarinin Base i dir.Tum hata siniflari .Net te 
                //bir Exception dir yani Exception dan inherit edilir bunu F12 ile de Exception ustune giderek cek edebiliriz
                //(Exception) tum hata siniiflarinin referansini tutabilir.Iste bu yazdigimiz (Exception) hangi turde
                //hata yakalamak istedigimizi anlatir.Exception olursa tum hatalarin base i oldugu icin biz
                //catch(Exception) yazinca tum hata cesitlerini orda kullanabiliyoruz...
                //Biz Exception base class inin altinaki diger exception lari da kullanabiliriz ornegin
                //catch(DivideByZeroException) olur da bolumunde 0 olan bu tur bir exception alirsa demektir,yani hatanin
                //turu 0 a bolum hatasi ise su hareketi yap sen ona diye hatayi anlamli hale getirebiliyoruz
                //UYGULAMADA ONGORDUGUMUZ HATALARA GORE SISTEMIN NE YAPMASI GEREKTIGINI SOYLERIZ BIZ
                //DIVIDEBYZEROEXCEPTION GIBI EXCEPTION ALTINDAKI METHODLARLA...

            }//0 a bolunme hatasindan sonra baska bir hata olmasini ongorursek bu sekilde bir catch blogu daha
            //yazarak devam edebiliriz..
            catch (DllNotFoundException)
            {
                Console.WriteLine("Catch calisti ve baska bir hata olustu");
                throw new DllNotFoundException();
            }
            //Gercek hayat projelerinde su hata olursa yonetime mail at, mesela bir bankacilik islemlerinde
            //olusan hatanin turu bizim icin cok onemli olabilir.Boyle bir hata olursa yonetime mail at,soyle bir hata
            //olursa risk birimine mail at, su tur bir hata olursa subeye mail at, ya da soyle bir hata olursa
            //kullaniciya mail at
            //Ornegin eger internet bankaciligi kullanirsak biz bir kullanici olarak boyle seyler yasayabiliriz
            //Mesela login olmaya calisirsin kullanici bilgilerini yanlis girersin hemen mesaj atar uygulama bize
            //ne diye mesaj atar senin uygulamana yanli sifre ile giris yapilmaya calisildi, haberin var mi diye
            //Iste hatanin o anki durumuna  gore biz onlem aliriz ve uygulamanin ne yapmasi gerektigini soyleriz
            //Bu yazdigimiz DivideByZeroException ve DllNotFoundException hata turlerini biz ongorebildigimiz hatalar
            //olarak dusundukk burda yani tahmin edebileceklerimiz.Peki ya ongoremediklerimiz icin ne yapariz...
            //O zaman da Exception diye yazariz cunku Exception hepsinin base i zaten biz hatanin turunu ongoremiyorsak
            //o zamana catch parantezi icine Exception yazariz ki Exception hepsinin base i oldugu icin hepsinin
            //referansini tutabiliyor...
            catch (Exception exception)
            {
                Console.WriteLine("Hic ongormedigim bir hata olustu, yoneticinize basvurun");
                //Genellikle biz bu tarz hata durumlarinda hemen loglama yapariz ki o hatayi artik dosyaya loglama olur
                //veya sms loglama olur herhangi biri ile kaydederiz ki sistem yonteiciside o hatanin detayina
                //turune baksin ve ona gore cozum u ile ugrassin...
                //ONEMLI HATA BILGISI ALMA NASIL OLUR!!!!
                //Peki hata bilgisini nerden aliriz Exception yanina yazacagimiz exception degiskeniinden aliriz
                //Olusan hata turu bilgisi icin bir degisken yapariz Exceptin Base nesnesi yanina
                // catch (Exception exception)
                Console.WriteLine("Hata bilgisi loglandi, sistem yoneticisine sms olarak ve file olarak");
                Console.WriteLine(exception.Message);//ya boyle hata bilgisi aliriz 
                //Veya daha detayli bir bilgi almak istersek de innerException ile detayli hata bilgisi alabiliriz...
                Console.WriteLine(exception.InnerException);
                throw;//throw demek ayni hatayi firlat demektir, bu sekilde  de kullanilmaktadir... 

                //ONEMLI BURAYA DIKKAT
                //Biz eger birden fazla catch kullaniyorsak gidip en ustteki catch parametresine eger Exception 
                //yazarsak o zaman alttaki digerlerini kullanamayiz cunku zaten Exception tum hata turlerinin basei
                //oldugu icin altta yazilanlar zaten Exception icinde var onun icin alttakilere inmez catch oyle
                //bir durumda ondan dolayi biz boyle detayli bir hata turu donusumu ve yonetimi yapmak istersek
                //catch(Exception) i en son catch de en alttaki catch parametresine kullanmaliyiz...
            }
            //FINALLY BLOGU-OPSIYONELDIR-ISTER TRY CALISIN, ISTERSE DE CATCH CALISIN FARKETMEZ EN SON CALISACAK
            //OLAN FINALLY BLOGUDUR..HER DURUMDA.COK YAYGIN OLMASA DA KULLANILMAKTADIR...
            finally
            {
                Console.WriteLine("Finally calisti!");
            }

        }
    }
}
