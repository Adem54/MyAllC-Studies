using HomeWork.Abstract;
using HomeWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{
    class PersonCheckManager : IPersonCheckService
    {
      

        public bool CheckIfRealPerson(Person person)
        {
            return true;
        }
    }
}
