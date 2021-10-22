using HomeWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Abstract
{
    interface IPersonCheckService
    {

        bool CheckIfRealPerson(Person person);
    }
}
