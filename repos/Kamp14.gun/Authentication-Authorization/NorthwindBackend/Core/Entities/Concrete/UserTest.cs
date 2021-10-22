using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class UserTest : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
///Isin icinde sifreleme olan herseyi bizim byte[] formatinda veriyor olmamiz gerekiyor
///Karmasik algoritmalar vs byte[] ile tutulur
///byte string olarak girdigimiz veriyi ornegin her bir karakteri 2 karakter olarak girer
///Dolayisi ile de hashing ve salting yapmaya uygun bir veri tipidir
