using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.Result
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data):base(true,data)
        {

        }
        public SuccessDataResult(T data,string message):base(message,true,data)
        {
                
        }
    }
}
