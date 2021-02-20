using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(string message,bool success,T data):base(message,success)
        {
            Data = data;
        }
        public DataResult(bool success, T data):base(success)
        {
            Data = data;           
        }
        public T Data { get ; set ; }
    }
}
