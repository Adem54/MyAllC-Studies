using Project4.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Proje4.DataAccess
{
    public class EfCustomerDal : ICustomerDal
    {
        public void Add(Customer entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedCustomer = context.Entry(entity);
                addedCustomer.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
