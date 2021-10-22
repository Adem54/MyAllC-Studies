using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaimTest> GetClaims(UserTest userTest);
        void Add(UserTest userTest);
        
        UserTest GetByEmail(string email);
    }
}
