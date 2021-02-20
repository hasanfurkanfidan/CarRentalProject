using FluentValidation;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HsanFurkanFidan.CarRentalProject.Business.ValidationRules
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.BrandId).GreaterThanOrEqualTo(1);
            RuleFor(p => p.ColorId).GreaterThanOrEqualTo(1);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(1);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
        }
    }
}
