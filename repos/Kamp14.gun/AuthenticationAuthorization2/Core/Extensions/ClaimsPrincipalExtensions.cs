using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
  public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            //claimPrincipal icinde bir virtual methoddur
            //public virtual IEnumerable<Claim> FindAll(Predicate<Claim> match);
            return result;
            //Yetkileri bulduk ve bir listeye attik
            //Simdide bize ClaimRoles adli extension gerekiiyor
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }

}
