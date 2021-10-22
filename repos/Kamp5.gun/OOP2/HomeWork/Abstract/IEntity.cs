using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Abstract
{
    interface IEntity
    {
         int Id { get; set; }
         string FirstName { get; set; }
         string LastName { get; set; }
         DateTime DateOfBirth { get; set; }
         string IdendifyNo { get; set; }
    }
}
