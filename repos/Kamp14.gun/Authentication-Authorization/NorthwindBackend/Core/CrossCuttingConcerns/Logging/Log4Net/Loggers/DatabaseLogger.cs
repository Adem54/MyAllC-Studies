using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Loggers
{
  public  class DatabaseLogger:LoggerServiceBase//Bu neden altini ciziyor cunku bunun 2 ihtimali var
        //LoggerServiceBase abstract class tir ve icerisinde override edilecek implement edilemyi
        //bekleyen methodlari vardir implement deyip olnlari getiririz ya da 
        //Ikinci ihtimal ise LoggerServiceBase icinde bunu biz yazdik ve parametre almis bir
        //constructor operasyonu old icin burda da bizim bir constructor olusturup sonunda
        //:base seklinde bir kullanim yapmamiz gerekiyor....
     
    {
        // <logger name="DatabaseLogger"> log4net.config deki bu satirdan geliyor "DatabaseLogger ismi
        //Yani bizim :base() icine yazacagimiz bu ifade log4net.config deki satirdaki ayni ifadeyi girmeliyioz
        public DatabaseLogger():base(name:"DatabaseLogger")    
        {

        }
    }
}
