using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.jwt
{
   public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
//Icerisinde bir tane Token properties I olacak bir tane de Expiration
//    adinda token imizin ne kadar sure gecerli oldugu bilgisi olacaktir