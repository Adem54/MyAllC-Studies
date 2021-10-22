using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //Bir tane referans tutucu lazimm di bize bizde ne yaptik hemen gidip
        //ProductVAlidator un inherit ettigi AbstractValidator un icine girdik F12 ile ve 
        //Onun implement ettigi interface var mi onu inceledik cunku biz biliyoruz ki ProductValidator
        //tipimizi AbstractValidator referansini tutabildigi gibi ayni zamanda onun implement ettigi
        //interface ler ve inherit etttigi nesneler de ProductValidator un referansini tutabilir..
        //Core katmanina da FluentValidation i yuklememiz gerekiyor...
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
