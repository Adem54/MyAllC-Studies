using HomeworkSolution.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkSolution.Concretes
{
    class GamerManager : IGamerService
    {
        IUserValidationService _userValidationService;

        public GamerManager(IUserValidationService userValidationService)
        {
            _userValidationService = userValidationService;//Bu islemle disardan bir class i ben bu class icerisindeki tum
            //operasyonlarda kullanma firsati vermis oluyorum....
        }
        public void Add(Gamer gamer)
        {
            if (_userValidationService.Validate(gamer))//Boyle yazabilirz default u true dir zaten
            {
                Console.WriteLine("Kayit eklendi!");
            }else
            {
                Console.WriteLine("Bilgileriniz dogrulanamadi!Kayit yapilamadi!");
            }


            
        }

        public void Delete(Gamer gamer)
        {
            Console.WriteLine("Kayit silindi!");
        }

        public void Update(Gamer gamer)
        {
            Console.WriteLine("Kayit guncellendi! ");
        }
    }
}
