using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Proje4.DataAccess
{
    public class EfPersonelDal : IPersonelDal
    {
        public void Add(Personel entity)
        {
           
        }

        public void Delete(Personel entity)
        {
            
        }

        public List<Personel> GetAll()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Personels.ToList();
                
                
               
            }
        }

        public Personel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Personel entity)
        {
            throw new NotImplementedException();
        }
    }
}
