using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTest.Entities
{
 public class Game:IEntity
    {
        public  int Id { get; set; }
        public string GameName  { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
