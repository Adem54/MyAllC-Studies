using System;

namespace Constructor5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");




            // Class Parent has only one constructor, which takes two int parameters.  
            //  Parent exampleParent1 = new Parent(10); // CS1729  
            // The following line resolves the error.  

            Child2 child = new Child2();
            Console.WriteLine(child.I);
            Console.WriteLine(child.J);
          


           
        }
    }

    public class Parent
    {
        // The only constructor for this class has two parameters.  
        public Parent(int i, string j):this(j)//Bu constructor calisinca alttaki constructor da calissin demektir
                                           //Yani ayni anda bir classi 2 kez farkli constructor versiyonlari ile new lemis 
                                           //gibi oluyor!!!!!!
        {
            I = i;        
        
        }

        public Parent(string j )
        {
            J = j;
           
        }


        public int I { get; set; }
        public string J { get; set; }



    }

    // The following declaration causes a compiler error because class Parent  
    // does not have a constructor that takes no arguments. The declaration of  
    // class Child2 shows how to resolve this error.  
    //public class Child : Parent { } // CS1729  //Burda hata verir cunku Child classi Parent i base class olarak
    //inherit etmis ama onun icindeki constructor lar burada kullanilmamis 
    //Eger bir class in constructor lari var ve bu class bir base class oluyorsa baska bir class tarafindan inherit edilirse
    //o class argumentleri yani parametreleri ile beraber inherit edildigi class da asagidaki sekilde kullanilmalidir!!!!

    public class Child2 : Parent
    {
        // The constructor for Child2 has only one parameter. To access the
        // constructor in Parent, and prevent this compiler error, you must provide
        // a value for the second parameter of Parent. The following example provides 0.
        //Childe2 de biz constructor kullanmaliyiz cunku base class imiz olan Parent icersiinde constructor var
        //Bizim Child2 de constructor i kullanirken bize saglayacagi sudur biz Parent icindeki ornegin 2 tane parametresi olan
        //constructor in parametresinin birini biz Child2 constructor inin parametresinde veririz ve onu Parent constructorunu
        //kullandigimiz base() icine yazariz Parent constructor inin diger parametresini ise dogrudan deger olaran vermeliyiz!!!!!!
        //Bu ozellikle bizim icin bir deger default olarak verilecekse bu tarz durumlarda kullanilir!!!!!
        public Child2() : base(5, "Child2")
        //Child2 class i calistiginda onun base class i yani onun inherit ettigi class in 2 parametreli
        //constructor i da calissin
        //Yani burda Child2 class i ni new ledigimiz zaman ve paranteze verileri de verdigmiz zaman
        //2 tane class birden new lenmis olacak ve biz verilere propertiesler uzerinden ulasacagiz...
        //Yani Parent base class i da
        {
            // Add the body of the constructor here.  
        }
    }
}
