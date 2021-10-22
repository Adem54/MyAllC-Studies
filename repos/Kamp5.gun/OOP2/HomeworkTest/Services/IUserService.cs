using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Services
{
 public  interface IUserService
    {
        void Add(User user);
        void Delete(User user);
        void Update(User user);
    }
}
