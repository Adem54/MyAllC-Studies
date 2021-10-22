using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
 public  class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}

//Student class i ayni zamanda bir tiptir ayni int gibi,string gibi
//Ve int ve string de arka planda aslinda bir class dir..
//