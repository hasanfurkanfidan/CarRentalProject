using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.Result
{
    public class ErrorResult:Result
    {
        public ErrorResult(string message):base(false)
        {
                
        }
        public ErrorResult():base(false)
        {

        }
    }
}
