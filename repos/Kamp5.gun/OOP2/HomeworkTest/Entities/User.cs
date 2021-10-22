using HomeworkTest.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest
{
  public class User:IEntity
    {
        public int UserId { get; set; }
        public int PassportNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataOfBirth { get; set; }
    }
}
