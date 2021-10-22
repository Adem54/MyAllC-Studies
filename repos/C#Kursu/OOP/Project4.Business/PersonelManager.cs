using Proje4.DataAccess;
using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project4.Business
{
    public class PersonelManager : IPersonelService
    {
        IPersonelDal _personelDal;

        public PersonelManager(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }
        public void Add(Personel personel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Personel personel)
        {
            throw new NotImplementedException();
        }

        public List<Personel> GetAll()
        {
            return _personelDal.GetAll();
        }

        public Personel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Personel personel)
        {
            throw new NotImplementedException();
        }
    }
}
