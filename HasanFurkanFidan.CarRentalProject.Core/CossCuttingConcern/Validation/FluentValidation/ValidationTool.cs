using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.CossCuttingConcern.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object data)
        {
            var context = new ValidationContext<object>(data);
            var validate = validator.Validate(context);

            if (validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
        }
    }
}
