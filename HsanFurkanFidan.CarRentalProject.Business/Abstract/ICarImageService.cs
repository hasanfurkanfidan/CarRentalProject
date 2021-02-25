using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HsanFurkanFidan.CarRentalProject.Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetListByCarId(int carId);
        IResult AddImages(CarImage carImage);

    }
}
