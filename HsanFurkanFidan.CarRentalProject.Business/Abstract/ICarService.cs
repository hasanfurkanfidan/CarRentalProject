using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HsanFurkanFidan.CarRentalProject.Business.Abstract
{
    public interface ICarService
    {
        Task<IDataResult<List<Car>>> GetAllCarsAsync();
        Task<IDataResult<Car>> GetCarByIdAsync(int id);
        Task<IDataResult<List<Car>>> GetListByBrandIdAsync(int brandId);
        Task<IDataResult<List<Car>>> GetListByColorIdIdAsync(int colorId);
        Task< IDataResult<Car>> AddCarAsync(Car car);
        Task<IResult> DeleteAsync(Car car);
        Task<IResult> UpdateAsync(Car car);
        Task<IResult> RemoveRangeAsync(List<Car> cars);

    }
}
