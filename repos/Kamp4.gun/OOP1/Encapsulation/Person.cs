using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    class Person
    {
        public int Id { get; set; }

        private string _firstName;
        //_firstName i biz privat e olarak field da tutuyoruz ama properties de public properties de ise get te return diyerek
        //private da tuttugmuz field da tuttugumz _firstName i cagiriyoruz ona donduruyoruz.Ayni sekilde set yapinca da yine
        //field da tuttugmuz private olarak tuttugumuz _firstName i set ediyoruz
        //Bir field uzerinde get veya set yapmak isterken baska birsey de eklemek istersek field a _firstName i private tutarak
        //kimsenin erisememisini saglariz ama public prop lar da da onu cagiraririz
        //Ornegin implemesyon detayinin gizlenmesi deniyor bu da encapsulation denir
        public string FirstName {
            get { return "Mrs. "+ _firstName; }
            
            set {
                _firstName = value;//value set etmeye calistigimiz deger karsilik gelecektir
                   
            }
                
                
                }
        public string LastName { get; set; }
       

    }
}
