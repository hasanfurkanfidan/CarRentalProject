using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.BusinessRules
{
    public class BusinessRule
    {
        public static IResult Run(params IResult[]logics)
        {
            foreach (var logic in logics)
            {
                if (logic.IsSuccess==false)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
