using Business.Abstract;
using Business.Constants;

using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(User user)
        {
            _userDal.Add(user);
            
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetUserClaimDto(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
            //Bu email donmuyor, bu bir user donuyor hangi useri bu email e sahip olan user i doner
            //Bu demek oluyor ki sen bu user a ait email e de passworde de erisebilirsin...
            //Email uzerinden user a ulasiyor...
        }
    }
}
