using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.Result
{
    public interface IDataResult<T>:IResult
    {
        public T Data { get; set; }
    }
}
