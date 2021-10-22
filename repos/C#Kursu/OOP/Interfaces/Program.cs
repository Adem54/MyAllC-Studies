using System;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IPersonManager personManager = new CustomerManager();

            ProjectManager projectManager = new ProjectManager();
            projectManager.Add(new CustomerManager());
            projectManager.Add(new EmployeeManager());
            projectManager.Add(new InternshipManager());
           
          
        }
    }

    //Interface lerde bir sablon belirleriz ve o interfac i implement eden class lar o sablona, interface in o 
    //imzasina ya da tasarimina uymak zorundadir...
    interface IPersonManager
    {
        void Add();
    }

    public class EmployeeManager : IPersonManager
    {
        public void Add()
        {
            Console.WriteLine("Employee eklendi");
        }
    }
    class CustomerManager : IPersonManager
    {
        public void Add()
        {
            Console.WriteLine("Customer eklendi");   
        }
    }

    class InternshipManager : IPersonManager
    {
        public void Add()
        {
            Console.WriteLine("Internship eklendi");
        }
    }

    class ProjectManager
    {
        public void Add(IPersonManager personManager)
        {
            personManager.Add();
        }
    }

}
