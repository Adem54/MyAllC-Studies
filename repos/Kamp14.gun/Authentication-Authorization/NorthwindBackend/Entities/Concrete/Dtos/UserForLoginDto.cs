using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete.Dtos
{//Login olmak isteyen bir kullanici da bu verilerle gelecek bize....
  public  class UserForLoginDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
