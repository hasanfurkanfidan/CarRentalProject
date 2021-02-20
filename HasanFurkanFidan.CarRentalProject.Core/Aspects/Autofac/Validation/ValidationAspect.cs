using Castle.DynamicProxy;
using FluentValidation;
using HasanFurkanFidan.CarRentalProject.Core.CossCuttingConcern.Validation.FluentValidation;
using HasanFurkanFidan.CarRentalProject.Core.Utilities.AOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterceptionAttribute
    {
        private readonly Type validatorType;
        public ValidationAspect(Type validatorType)
        {
            this.validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            var entityType = validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(p => GetType()==entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
