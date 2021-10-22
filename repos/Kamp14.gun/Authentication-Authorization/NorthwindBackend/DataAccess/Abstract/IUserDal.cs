using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public  interface IUserDal:IEntityRepostory<UserTest>
    {
        //Bir kullanicinin rollerini cekmek icin buraya bir ek operasyon yazariz...
        //Parametre olarak verdigim kullanicinin claimlerini cekmek istiyorum
        //Ben kullanicinin rollerine de ulasabilmeliyim ve bu kullanici rolleri tamamen 
        //buraya ozel bir operasyondur
        //Bu bizim icin bir join operasyonu olacak!!!!
        List<OperationClaimTest> GetClaims(UserTest userTest);
    }
}
