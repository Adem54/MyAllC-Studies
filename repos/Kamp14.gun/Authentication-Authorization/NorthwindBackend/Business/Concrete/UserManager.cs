using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(UserTest userTest)
        {
            _userDal.Add(userTest);
        }

        //Neden bu operasyonu yaptik cunku login olmak isteyen bir kullanicinin emailini veritabanin
        //dan cek etmeliyiz once
        public UserTest GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }//

        //Bu da bize bizim bu kullaniciya kaynaklari acmak icin yetkisi var mi onu bilmemiz icin
        //kullanicinin yetkilerini kontrol etmemiz gerekir...
        public List<OperationClaimTest> GetClaims(UserTest userTest)
        {
            return _userDal.GetClaims(userTest);
        }
    }
}

//Authentication islemleri-Kullanicinin sisteme kayit olmasindan sonra sisteme girmek isteye bir
//kullanicinin bilgilerinin dogrulanmasidir peki
//Authentication Prosessi
//Kullanicinin Login olmasi-Register olmasi,kayit olmasi
//KUllaniciya Token vermek
//Kullanici login olmak istediginde biz once kullanicinin onceden kayitli bir kullanici olup olmadig
//ini cek ederiz ve kayitli ise devam ederiz degilse kaytli degilsin kayit ol diye mesaj doneriz..
