﻿using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface IPersonService
    {
        void Sell(Product product,IPerson person);
    }
}
