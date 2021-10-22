using System;

namespace DependencyInjection2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //public class AccountCreator
    //{

    //    private AccountChecker _accountChecker;
    //    private AccountRepository _accountRepository;

    //    public AccountCreator()
    //    {
    //        _accountChecker = new AccountChecker();
    //        _accountRepository = new AccountRepository();
    //    }


    //}

    //https://atarikguney.medium.com/dependency-injection-nedir-1124c15249ad
    //Bu adres bu notlari aldigim site..

    //OLMASI GEREKEN BU ASAGIDAKIDIR YUKARIDA OLAN ISE KESINLIKLE BAGIMLI OLANDIR YAPILMAMALIDIR
    //BIR CLASS ICINDE BASKA BIR CLASS NEW LEMEK MANTIKLI BIRSEY DEGILDIR NEW LEDGINI CLASS A SUREKLI BAGIMLISIN DEMEKTIR

    public class AccountCreator
    {
        // Interface'ler tanımlıyoruz. Dolayısıyla kendi sınıflarımızı rahatlıkla kullanabiliriz.
        private IAccountChecker _accountChecker;
        private IAccountRepository _accountRepository;

        // Dependency'lerimizi constructor method vasıtasıyla enjekte ediyoruz.
        public AccountCreator(IAccountChecker accountChecker, IAccountRepository accountRepository)
        {
            _accountChecker = accountChecker;
            _accountRepository = new accountRepository;
        }

        //YAPACAGIMIZ OPERASYONLAR BURDA YAPILABILIR....

    }





}
