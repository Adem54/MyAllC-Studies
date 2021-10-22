using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete 
{//class, method ve prop isimlleri pascal case yani ilk harf buyuk verilir
    public class Person
    {  //property eklerken prop deyip tab a iki kez tikariz. Propertyleri get ve set bloklari ile olustururuz cunku sonradan yapacagimiz
       //degisikliklerde cok kolay yapabiliriz get ve set sayesinde
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public long NationalIdentity { get; set; }
        public int DateOfBirthYear { get; set; }
    }
    //Varlıklarımızı entities dosyasında tutarız
    //Yeni bir Business adında cs dosyası oluşturduğumuzda onun içerisine abstract ve concrete şeklinde soyut ve somut adında klasörler açarak 
    //Soyut nesnelerimizi tutması için abstract, somut nesnelerimiz tutmaları için ise concrete klasörünü açarız
}
