using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidatoinRules.FluentValidation
{
  public  class ProductValidator:AbstractValidator<Product>
    { //FluentValidation i bir constructor vasitasi ile devreye sokabiliyoruz...
      //ProductValidator un bir Validator olabilmesi icin FluentValidaton dan gelen AbstractValidator den
      //inherit edilmesi gerekiyor
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("ProductName musn't be empty");
            RuleFor(p => p.ProductName).Length(2, 30);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 2);
            RuleFor(p => p.ProductName).Must(StartWithA);//Bu sekilde de kendi methodumuzu

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
