using System;

namespace StaticClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Messages.ProductAdded);
            Console.WriteLine(Messages.ProductNameInvalid) ;
            Console.ReadLine();
        }
    }

    public static class Messages
    {//STatic bir constant tir yani sabit yapi
        //public field yazalim tabi ki static yapmaliyiz onu da class i static yaptigimiz icin...
        public static string ProductAdded = "Ürün eklendi!";
        //Burdaki degiskenler public oldugu icin buyuk harfle yazilir ama private olsa idi o zaman kucuk harfle yazardik
        public static string ProductNameInvalid = "Ürün ismi geçersizdir!";
        public static string MaintenanceTime = "Sistem bakımda";//Biz otomatik generate field yaptigimiz icin default getirmis burayi
        //duzeltelim!!! string yapalim ayrica internal de default bir field dir
        public static string ProductsListed = "Ürünler Listelendi";
    }

}
//static ler new lenmez uygulama hayati bouyunca tek instanceleri olur ve bu mesajimizda zaten sabit olacagi icin
//ver her mesaji verdgimiz de surekli surekli newlememek icin burayi static yapariz...
//Bu yapi dogrudan class ismi . diyerek calisir...new lenmez ama sabit bir yapidir 
//Bu tip yapilari static yapariz...
//Bu yaptigimiz intro seviyedir bunun cok dil destekli versiyonlari icin DevARchitecture i mutlaka incelemelisin!!!!
//Bunu aslinda cok dil destekli yapi ile yine bir injection teknigi ile daha farkli bir noktaya getirebilriz ornegin
//IMessages ile turkcler ingilizceler gibi