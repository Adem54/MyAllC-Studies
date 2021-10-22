using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidaton
{
   public class ProductValidator:AbstractValidator<Product>
    {

       public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();//ProductName bos olamaz!!
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();//UnitPrice bos olmamali
            RuleFor(p => p.UnitPrice).GreaterThan(0);//UnitPrice o dan buyuk olmali

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Products must start with A letter");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }

    }
}
