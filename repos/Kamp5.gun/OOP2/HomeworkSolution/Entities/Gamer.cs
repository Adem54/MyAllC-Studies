using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkSolution
{
    class Gamer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public long IdendityNumber { get; set; }
    }
}
//Biz gamer i normalde bir user dan inherit ederek yapabilirdik ve user a temel bilgileri  koyardik ve o zaman daha advance olurdu