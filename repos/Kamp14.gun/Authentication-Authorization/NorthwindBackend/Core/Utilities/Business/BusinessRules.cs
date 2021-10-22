using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public  class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
               
            }
            return null;//Cunku bu durumda zaten Add methodunda ise ekleme islemi calissin diyoruz
                        //yani sirf return dondermek icin yazdigimiz icin null olsun diyoruz....
        }
    }
}
