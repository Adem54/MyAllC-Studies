using HomeWork.Abstract;
using HomeWork.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork.Concrete
{
    class PersonManager:IPersonService 
    {
        //Asagidaki operasyonlari yapmadan once dogrulama islemini yapmaliyim

        IPersonCheckService _personCheckService;

        public PersonManager(IPersonCheckService personCheckService)
        {
            _personCheckService = personCheckService;
        }

   
        public void Add(Person person)
        {
            if (_personCheckService.CheckIfRealPerson(person))
            {
                Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.IdendifyNo + " bilgileri dogru oldgu icin  eklendi");
            }else
            {
                Console.WriteLine("Girilen bilgiler yanlistir");
            }

            
        }

        public void Delete(Person person)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.IdendifyNo + "   silindi");


        }

        public void Update(Person person)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName + " " + person.IdendifyNo + "  guncellendi");
        }
    }
}
