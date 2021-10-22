using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
  public  class SigningCredentialsHelper
    {
        //SigningCredentails turu de Microsoft.IdentityModel.Tokens paketinden geliyor....
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            //SecurityAlgorithms.HmacSha256Signature Microsoft.IdentityModel.Tokens dan geliyor
        }
    }
}
