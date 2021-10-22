using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
 public  class LogParameter
    {
        //Burasi Loglanacak operasyondaki parametrenin bilgileridir
        //[LogAspect()] biz LogAspect i yazinca onun parametresine ait
        //Yani integer bir alan ismi ve degeri gibi dusunebiliriz
        public string Name { get; set; }
        //Ornegin bir product nesneniz var ve isim olarak da instance ye product dediniz diyelim iste name o
        public object Value { get; set; }
        //Value si Name in degeri product isimli bir instancenin ornegin Id si 1 FirstName i Elma gibi
        public string Type { get; set; }
        //Type ise Product type 

    }
}
