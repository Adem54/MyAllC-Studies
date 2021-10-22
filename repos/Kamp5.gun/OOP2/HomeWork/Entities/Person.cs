using HomeWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Entities
{
    class Person:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdendifyNo { get; set; }


    }
}

//DateTime System icerisinde bir class tir biz onun icerisinden tarih ile ilgili 
//DateTime yeniTarih = new DateTime(yıl , ay, gün);
//DateTime yeniTarih2 = new DateTime(yıl, ay, gün, saat, dakika, saniye);