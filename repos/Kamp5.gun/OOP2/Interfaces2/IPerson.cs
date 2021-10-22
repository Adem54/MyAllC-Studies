using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces2
{//Interface lerde public olmaz cunku default olarak onlar publictir zaten
    interface IPerson
    {
         int Id { get; set; }
         string FirstName { get; set; }
        string LastName { get; set; }

    }
}

//Interface ler soyut nesnelerdir onu implement eden class lar ise soumt nesnelerdir
//Genellikle Operasyonlar icin yani methodlar icin kullaniriz
//Interface lerde sadece tasarim bulunur, imza bulunur ve burda bulunan imzalar onu implement eden class larda olmak zorundadir
//Interface i implement eden class lar ortak olarak interface deki propeerties leri veya operasyonlari kullanmakla beraber
//ayrica sadece kendine has property veya operasyonlar tutabilir
//Interface de biz temel bir tasarim veya temel bir arayuz yapariz ve sonra onu diger class lar implemente ederler

//Biz interface leri daha cok bir servis implementasyonu yaparkem veya katmanlar arasi gecis yaparken kullaniriz