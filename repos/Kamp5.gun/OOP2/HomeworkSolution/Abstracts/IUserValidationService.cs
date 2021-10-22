using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkSolution.Abstracts
{//UserValidation=>Kullaniciyi dogrulama
    interface IUserValidationService
    {//Biz burda Gamer i bir User adli bir inherit edilmis ortak bir property class indan da getirebilirdik ki yarin oburgun biz
        //sisteme sadece oyunculari degil baska person tiplerini de kaydedebilmek icin...
        //Yani property classs lari olustururduk ve ortak bir class olusturup ortak verileri onda tutardik ve bu parametreye de
        //o ortak class i verirdik ki o ortak class i da diger property class lar ya inherit ederdi ya da interface olarak verirsk
        // de implement ederdi...
        bool Validate(Gamer gamer);
    }
}
