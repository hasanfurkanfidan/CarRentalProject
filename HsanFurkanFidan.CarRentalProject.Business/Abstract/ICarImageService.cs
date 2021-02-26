using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HsanFurkanFidan.CarRentalProject.Business.Abstract
{
    public interface ICarImageService
    {
        Task<IDataResult<List<CarImage>>> GetAllAsync();
        Task<IDataResult<List<CarImage>>> GetListByCarIdAsync(int carId);
        Task<IResult> AddImageAsync(CarImage carImage);
        Task<IDataResult<List<CarImage>>> GetImagesWithCarId(int carId);

    }
}
