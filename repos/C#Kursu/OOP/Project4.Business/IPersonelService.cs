using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project4.Business
{
 public   interface IPersonelService
    {
        List<Personel> GetAll();

        Personel GetById(int id);
        void Add(Personel personel);
        void Delete(Personel personel);

        void Update(Personel personel);

    }
}
