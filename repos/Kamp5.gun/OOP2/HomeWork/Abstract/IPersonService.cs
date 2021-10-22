using HomeWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Abstract
{
    interface IPersonService
    {  
        void Add(Person person );
        void Update(Person person);
        void Delete(Person person);

    }
}
