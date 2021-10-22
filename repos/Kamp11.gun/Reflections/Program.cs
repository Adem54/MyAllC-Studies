using System;
using System.Reflection;

namespace Reflections
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //DortIslem dortislem = new DortIslem(5, 3);
            //Console.WriteLine(dortislem.Topla(5, 8));//Ekstra parametre istiyor kullanicidan
            //Console.WriteLine(dortislem.Topla2());//kullanicidan gelen degerleri kullaniyor dogrudan
            //Kullaniciya alternatif sunuyoruz ister toplama icn ekstra parametre versin istersede dogrudan
            //constructor dan gelen degerlerle toplama islemleri yapilabilir

            //BIZ BU YAPTIGIMIZ ISLEMLERI REFLECTION ILE YAPAMAZMI IDIK ONA BAKALIM
            //Bu arada biz herseyi reflection ile yapmaya calismamaliyiz cunku reflectiion ihtiyac aninda
            //kullanilmalidir cunku biz bunu reflection ile calisma aninda kullandigimiz zaman ufakda olsa
            //bir performans kaybi yasariz, reflection pahali birseydir
            //Dolayisi ile gercekten calisma aninda ihtiyacimiz varsa reflectiona  ozaman yapmaliyiz
            //Yukarda yaptigimiz newleme ve method kullanimlarini reflection ile yapmayi deneyelim

            //REFLECTION KULLANIMI
            //En onemli sey type ile tum tipleri handle edebilldigimiz islemi yapmaktir
            var tip = typeof(DortIslem);//Bu bir instance degil sadece benim calisacagim tip DortIslem diyoruz
            //Class larda bir tiptir onu unutmayalim!!!!
            //Reflection da Activator denilen bir sinif var
            DortIslem dortIslem = (DortIslem)Activator.CreateInstance(tip);
            //Neyin instancesini olusturmak istiyorsan onuu yazarsin
                //Activator.CreateInstance obje dondururur.Tum tiplerin atasi obje dondurur
                //Ama biz var ile degil DortIslem turunde bu veriyi dondurmek istiyoruz
            //ADD EXPLICT CAST  
            //Onun icindde Cast denen islemi yaparak cozebbiliriz (DortIslem)Activator.CreateInstance(tip)
                //Biz burada problem yasamadik cunku bir de parametresiz constructor olusturduk classs da 
                //Yoksa sadece parametreli constructor olusturunca arka tarafta default olan parametesiz olan
                //constructor override oldu ezildi ondan dolayi biz tekrardan arka tarafta default calisan
                //constructor i onde de yazdik o zaman artik class new lerken paramtresiz de newleyebiliyoruz
                
             // Console.WriteLine(dortIslem.Carp(4,5));
            //PARAMETRELI OLAN VERSIYONU CALISTIRALIM BIRDE
            DortIslem dortIslem2 = (DortIslem)Activator.CreateInstance(tip, 9, 8);

            //REFLECTION ILE OLUSTURDUGUNUZ INSTANCENIN METHODUNU DA CALISTIRMA
            //METHODUN NE OLDUGUNU BILMEDEN REFLECTION ILE CALISTIRMA

            var instance = Activator.CreateInstance(tip, 12, 6);
            //instance.GetType().GetMethod("Topla2")=>Methoda ulasiyoruz ve instance ile olan bagi kaybeder
            //Invoke(instance,null)=>Ulastigimiz methodu calistiririz hangi instance ve parametreleri vermemiz
            //gerekiyor
            //MethodInfo class i Reflection ile gelir
           MethodInfo methodInfo= instance.GetType().GetMethod("Topla2");
           
            Console.WriteLine(methodInfo.Invoke(instance, null));
            Console.WriteLine("---------------------------------------");
            //REFLECTION ILE NESNEMIZE AIT OZELLIKLERE VEYA METHODLARINA,ATTRIBUTE LERINE
            //LISTE SEKLINDE ERISMEK
            //Methodlara liste seklinde ulasmak
            var methods = tip.GetMethods();// method class larinin listesini doner
            //Biz foreach ile donderince method nesnelerine ulasmis oluruz bundan sonra artik
            //methodlarin isimleri,parametreleri bunlarada ulasiriz
            foreach (var method in methods)
            {
                Console.WriteLine("Method adi : {0}", method.Name);
                //Methodlarin parametrelerine ulasmak
                foreach (var parameterInfo in method.GetParameters())
                {
                    Console.WriteLine("Parametre : {0}", parameterInfo.Name);
                }
                //Methodlarin Attributlerine ulasmak
                //Kendimiz asagida attribute tanimlayalim ve onu gorelim
                //Carp2 ye MethodName attribut u ekledik
                foreach (var attribute  in method.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name:{0}", attribute.GetType().Name);
                }
            }

            //Biz attribute lerle nesneye,methoda,propertye bir imza koyuyoruz yani bir anlam yukliyoruz
            //Attribute tamamen reflection iliskisi ile beslenen bir mimaridir

            //BURDAN YOLA CIKARAK NERDEYSE HERSEYE ULASABILIYORUZ ONUN ICIN REFLECTION LAR COK
            //ONEMLI BIZIM ICIN

            
           

            Console.ReadLine();
        }
    }

    public class DortIslem
    {  //Kullanicidan deger alabilmek icin
        private int _sayi1;//field olusturuyoruz
        private int _sayi2;
        //Constructor da verilen degerler kullanici tarafindan class
        // new lenirken class in new DorIslem(3,5) parantezine verilir.Ama constructor in parametresinde
        //olan bu degerler dogrudan disarida kullanilamaz C# da(javascripte kullanilir).Ondan dolayi
        //bizde once ustte int tipinde 2 tane degisken olusturup onlara parametredeki degerleri aktararak
        //constructor parametresindeki degerlerin global olarak Dortislem nesnesi icerisinde olusturacagimiz
        //tum methodlarda kullanilabilmesini sagliyoruz
        public DortIslem(int sayi1, int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }

        public DortIslem()
        {

        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }

        public int Topla(int sayi1, int sayi2)
        {
            return sayi1 + sayi2;
        }
        [MethodName("Carpma")]//Mesela methodun disariya baska bir isimle gorunmesini isteyebiliyoruz
        //Tamamen bu methoda bir anlam yuklemek amaci ile
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
    }

    public class MethodNameAttribute : Attribute
    {
      private  string _name;
        public MethodNameAttribute(string name)
        {
            _name = name;
        }
    }
}
//Reflection ile calisma aninda yani uygulamamiz calisirken calistigimiz herhangi bir nesnenin hakkinda
//bilgi toplayabilir ve hatta bu topladigniz bilgiye gore bu nesneyi istediginiz zaman ornegin bir 
//methodunu calistirabilirsiniz

//ORNEK SENARYO-1-REFLECTION KULLANIMINA
//Calisma ani uygulamamiz i execute ederken biz siyah ekran geldigi zaman eger ayrica yapmak 
//istedigimiz durumlara karsilik gelir
//Biz calisma aninda bir nesnenin instance olusturup onu calistirabiliriz
//Cok sik karsilastigimiz durumlardan biri de calisma aninda hangi nesne ile calisacagimizi bilememizdir
//Kullanicinin girecegi degerlere gore biz o an ne yapmamiz gerektigine karar verebiliyoruz
//Bir kullanici icin hangii nesnenin hangi methodunun kullanilacagina uygulamadaki gidisata gore karar vere
//biliyoruz
//Bunun farkli yontemleri de mevcuttur ama reflection yeri geldginde kurtarici olabiliyor
//ORNEK SENARYO-2-REFLECTION KULLANIMINA
//Nesneler hakkinda bilgi almak
//Bir tane elimizde Customer nesnesi var mesela bunun ozellikleri nelerdir ve bunun attribute leri varmi
//Varsa attribute leri isimleri nelerdir parametreleri nelerdir gibi bilgilere ulasmak isteyebiliriz
//Calisma aninda kullanicinin ekrana girdigi degerlere gore bir sorgu olusturmamiz gerekebilir
//Veritabanina bir insert veya bir select olusturmamiz gerekebilir
//Yani dinamik olarak customer nesnemizin ozelliklerine gore veritabanina bir sorgu yazabiliriz
//Reflection i ancak projelerimizde kullandigimiz zaman veya ihtiyacimiz  oldugu ve sonrasinda kullandigimiz
//zaman ancak anlamli hale gelecektir