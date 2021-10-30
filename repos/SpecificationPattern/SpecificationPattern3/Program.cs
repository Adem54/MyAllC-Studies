using System;
using System.Collections.Generic;

namespace SpecificationPattern3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Customer
    {
        public int CustomerID { get; set; }
        public string Fullname { get; set; }
        public decimal Salary { get; set; }
        public string City { get; set; }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }

    public static class CustomerAnalyzer
    {
        // Bu Customer listesinin bir şekilde bir yerlerden dolduğunu düşünelim
        private static List<Customer> customers = new List<Customer>();

        public static List<Customer> GetCustomerBySpecification(ISpecification<Customer> spec)
            //Normalde burasi bir veritabanindan gelecek olan contex olacaktir...
        {
            foreach (var customer in customers)
            {
                if (spec.IsSatisfiedBy(customer))
                    customers.Add(customer);
            }

            return customers;
        }
    }

    public class CustomerCitySpecification
        : ISpecification<Customer>
    {
        private string _city;

        public CustomerCitySpecification(string city)
        {
            _city = city;
        }
        public bool IsSatisfiedBy(Customer customer)
        {
            return customer.City.ToUpper() == _city.ToUpper();
        }
    }

    public class CustomerSalarySpecification
        : ISpecification<Customer>
    {
        private decimal _minimum;
        private decimal _maximum;
        public CustomerSalarySpecification(decimal minimum, decimal maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }
        public bool IsSatisfiedBy(Customer customer)
        {
            return (customer.Salary >= _minimum && customer.Salary <= _maximum);
        }
    }
}
