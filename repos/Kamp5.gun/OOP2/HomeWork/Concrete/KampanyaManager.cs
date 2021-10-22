using HomeWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{
    class KampanyaManager : IKampanyaService
    {
        public void AddKampanya()
        {
            Console.WriteLine("Yeni bir kampanya eklenmistir");
        }

        public void DeleteKapmanya()
        {
            Console.WriteLine("Kampanya silinmistir");
        }

        public void UpdateKampanya()
        {
            Console.WriteLine("Kampanya guncellenmistir");
        }
    }
}
