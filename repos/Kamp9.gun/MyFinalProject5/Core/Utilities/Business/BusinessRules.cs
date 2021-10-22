using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
public    class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach ( var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;//Hata mesajini verir burda
                }
                
            }
            return null;//Return donmek zorundasin ve birsey de donmek istemiyorsun o
                        //zaman null don
        }
    }
}
