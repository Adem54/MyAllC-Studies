using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class ForeignerManager : IApplicantService  //Aynı şekilde burda biz soyutlama classını bu şekilde yazınca
                                                //solda oluşan ampülden implement interface yaparsak bizim IApplicantService
                                                //adlı soyutlama interface classımızıdaki imza olarak koyduğumuz metodlarımızı burda altını doldurmamızı isteyecektir

    {//Yabancılar için verilecek maske için onun kuralını burda yaparız türkün kuralını da PersonManager classında yaparız
        public void ApplyForMask(Person person)
        {
            throw new NotImplementedException();
        }

        public bool CheckPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public bool CheckPerson()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetList()
        {
            throw new NotImplementedException();
        }

        public void NewMethod()
        {
            throw new NotImplementedException();
        }
    }
}
