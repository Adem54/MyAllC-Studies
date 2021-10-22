using HomeworkTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Managers
{
    public class UserManager : IUserService
    {
        IInfoVerificationService _infoVerificationService;
        public UserManager(IInfoVerificationService infoVerificationService)
        {
            _infoVerificationService = infoVerificationService;
        }
        public void Add(User user)
        {
            if (_infoVerificationService.CheckUserInfo(user)==true)
            {
                Console.WriteLine("Userdata verificated and User added");
            }
            else
            {
                Console.WriteLine("Bilgileriniz dogurlanamadi");
            }
            
        }

        public void Delete(User user)
        {
            Console.WriteLine("User deleted");
        }

        public void Update(User user)
        {
            Console.WriteLine("User updated");
        }
    }
}
