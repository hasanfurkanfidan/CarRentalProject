using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.Result
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data,string message):base(message,false,data)
        {
                
        }
        public ErrorDataResult(T data):base(false,data)
        {
                
        }
    }
}
