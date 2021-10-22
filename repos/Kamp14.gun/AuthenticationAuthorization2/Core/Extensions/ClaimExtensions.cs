using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        //Bu yaptigimiz extension ekleme yontemidir ekledigimiz extension larin
        //icinde claim ekliyoruz...dolayisi ile ekldigimiz extension i direk claims altinda 
        //claim eklemek icin kullanabilecegiz..

        //this ifadesi methodumuzun extension method oldugunu belirtir
        // ICollection<Claim> claims, bu method hangi tip icin gecerli onu gosterir
        // string email de ICollection<Claim> tipi parametre olarka email aldiginda gecerli olacak,....
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            //Bu bir claim ekleme yontemidir
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims,string nameidentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameidentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims,string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
