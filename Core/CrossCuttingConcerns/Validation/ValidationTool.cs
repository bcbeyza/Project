using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);//Bir ValidationContext nesnesi oluşturulur. Bu, doğrulama işlemi için gerekli olan bağlamı sağlar ve doğrulama kontrollerini gerçekleştirmek için kullanılır. ValidationContext nesnesi, doğrulanacak nesneyi içeren bir parametre alır.
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
