using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritancess2
{
    //Biz bir class ile hem bir interface i implement edip hem de baska bir class i inherit alabiliriz.....
    class Customer:Person,IPerson
    {
        public string City { get; set; }
        public string TcNO { get; set; }
    }
}
