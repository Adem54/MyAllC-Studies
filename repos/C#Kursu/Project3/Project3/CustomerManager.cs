using System;
using System.Collections.Generic;
using System.Text;

namespace Project3
{
  public  class CustomerManager
    {  //constructor  CustomerManager customerManager=new CustomerManager();//bu parantez constructor i temsil eder...
        List<Customer> customers;
        public CustomerManager()
        {
            customers = new List<Customer>
            {
                new Customer{Id=1, FirstName="Engin", LastName="Demirog", Email="engindemir@gmail",
                 City="Ankara"},
                 new Customer{Id=2, FirstName="Adem", LastName="Erbas", Email="adem5434@gmail",
                 City="Istanbul"},
                  new Customer{Id=3, FirstName="Mehmet", LastName="Kaya", Email="mehmet@gmail",
                 City="Izmir"},
                   new Customer{Id=4, FirstName="Ahmet", LastName="Serin", Email="ahmet@gmail",
                 City="Bursa"},
                    new Customer{Id=5, FirstName="Yahya", LastName="Masa", Email="yahya@gmail",
                 City="Adana"}
            };

         
        }
       
        public List<Customer> GetAll()
        {
           


            return customers;
        }

        public void Add(Customer customer)
        {
 
            customers.Add(customer);
        }
    }
}
