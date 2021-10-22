
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    //Bu da bir methodu nasil yorumlayacagimizi anlattigimiz yer olacak
    //Bunu da bir public abstract olarak isaretleriz
    //MethodInterceptionBaseAttribute u inherit ettirerek diyoruz ki MethodInterception a sende bir
    //attribute sun yani aspecttsin yani interceptor sun demis oluruz...
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //Method calismadan once calismasini istersek bu methodu n biz icini dolduracagiz nerde 
        //her CrossCuttingConcers uyeleri icinde ki her birinde nasil calismasini istiyorsam ona gore
        //icini orda dolduracagiz.Cunku mesela Validation,Authorization,Loglama vs gibi bunlarda
        //bir cogunda methoddan once calissin deriz ama method sonunda da calissin diyeceklerimiz olabilir
        //loglama gibi veya hata durumunda calismasini gormek isteyebilirz dolayisi ile bu senaryo
        //abstract class a ve virtual method a cok uygun onun icinde burasi abstract class ve virtual
        //methodla yazilmiss...
        //IInvocation bizim methodlarimizi temsil ediyor ve CasteCoreDynamicProxy den hazir geliyor...
        protected virtual void OnBefore(IInvocation invocation) { }
        //Method basinda sen calis
        protected virtual void OnAfter(IInvocation invocation) { }
        //Method bitiminde sen calis
        protected virtual void OnException(IInvocation invocation,System.Exception e) { }
        //Method hata verme durumunda calis
        protected virtual void OnSuccess(IInvocation invocation) { }
        //Method basarili ise calis

        //Dikkat edelim bu operasyonlarimiz asaguda calisiyor ama hicbiri su an bir ise yaramiyor neden cunku icleri bos
        //iclerinde birsey yok.Ben bunlari Aspectlerimde dolduracagim yani mesela ValidationAspect imde eger method basinda
        //calismasini istiyorsam o zaman ValidationAspect te gidip OnBefore u dolduracagim yani override edeceegim ya da mesela Loglama da basinda 
        //sonunda ve hata durumunda calissin istersem LogAspectte onlari icini doldururum ve onlar calisir.Zaten ben istedigim yerde
        //hangisine nerde ihtiyacim varsa orda kullanabileyim diye virtual yaptim ve direk hepsinin asagida bir methodun
        //calismasini yorumladim ve hangisine nerde ihtiyacim varsa orda icini dolduracagimn yani override edecegim, burda virtual method lardan da ciddi
        //faydalaniyoruz...
        
        //BU NESNE ARACILIGI ILE TUM CROSSCUTTINGCONCERN LERIMIZ METHOD UN NERESINDE CALISACAKSA
        //KENDI ASPECT INI INTERCEPT METHODUNU OVERRIDE EDEREK OLUSTURUR.....
        public override void Intercept(IInvocation invocation) 
        {//Bu bir methodun arasina girip calisacak ama nerde nasil yorumlayacagiz onu anlatacagiz burda
            var isSuccess = true;//Baslarken islemin basarili oldugunu varsayiyorum
            OnBefore(invocation);//Onunde OnBefore calistir yani methoddan once calistiriyoruz
            try
            {
                invocation.Proceed();//Eger hata yoksa methodu calistir
            }
            catch (Exception e)
            {

                isSuccess = false;//Hata old icin false yapariz
                OnException(invocation, e);//Bu hata hata durumundaki Aspect ler icin yazilir mesela
                //loglama yi biz hata durumunda da calissin  diyebiliyoruz...
                throw;
            }
            finally//Sonunda da her turlu basarili veya basarisiz olma durumunda kullanmakk istedigin birsey varsa boyle yazabilirz
            {
                if (isSuccess)//Yani basarili oldugunda calismasini istedigin araya girmesini istedigin bir corss cutting concers
                    //yani bir aspect imiz veya attribute umuz varsa o calissin diye yaziyoruz ornegin loglama islem baslarili
                    //oldugunda gorelim diyorsak mesela...
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);//Sonunda calisacak olan aspect yani araya girecek interceptor loglama gibi attribute icinde yazmak
            //istiyorsak o zaman da buraya OnAfter yaziyoruz
  
           
        }
    }
}
//Bir method un nasil ele alinacagini yazmis olduk!!!
//Biz bu altyapiyi olusturduk artik bizim CrossCuttingConcern lerimiz bu altyapiyi kullanacak!!!!
//Biz CrossCuttingConcern ler icin bir base olusturddukk yani bunu temel al diye, bir template olusturduk
//Kisacasi biz simdi altyapiyi kurduk sonrasinda artik bu abstract class i inherit edecek aspect ler nerde calistirilmalari gere
//kiyorsa orda calistirarak islerimizi cok kolaylastiracagiz....
