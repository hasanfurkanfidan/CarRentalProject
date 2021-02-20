using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(string message,bool success)
        {
            Message = message;
            IsSuccess = success;
        }
        public Result(bool success)
        {
            IsSuccess = success;
        }
        public string Message { get; set ; }
        public bool IsSuccess { get ; set ; }
    }
}
