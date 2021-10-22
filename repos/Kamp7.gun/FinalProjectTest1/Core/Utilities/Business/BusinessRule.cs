using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
  public  class BusinessRule
    {
        public static IResult Run(params IResult[] logics)//params ile virgulle ayirarak istedin kadar
                                                          //parametre ekleyebilirsin demektir,bunun bir yontemi de su olurdu liste isteyebilirdik
                                                          //params List<IResult> logics de yapabilirdik bu da olurdu 
        {
            foreach (var logic in logics)//Her bir is kuralini gez
            {
                if (!logic.Success)
                {
                    return logic;//Erroresult dondurecek
                                 //Parametre ile business e gonderdigimiz is kurallarindan basarisiz olani
                                 //business i haberdar ediyoruz kuralin kendisini business e dondurerek
                                 //yani ornegin kullanicinin gonderdigi veri bizim is
                                 // kuralimiza uymuyorsa basarisiz dir ve is kuralini haberdar ediyoruz

                }
            }
            return null;//Gonderilen veri is kurallrimiza uyuyorsa, basarili da birsey soylememize gerek yok

        }
    }
}
