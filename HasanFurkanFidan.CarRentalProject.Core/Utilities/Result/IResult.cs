using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Core.Utilities.Result
{
    public interface IResult
    {
        public string Message { get; set; }
        public bool  IsSuccess { get; set; }
    }
}
