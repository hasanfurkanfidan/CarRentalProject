using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using HasanFurkanFidan.CarRentalProject.DataAccess.Abstract;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using HsanFurkanFidan.CarRentalProject.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HsanFurkanFidan.CarRentalProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarManager(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public Task<IResult> AddCarAsync(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(Car car)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<Car>>> GetAllCarsAsync()
        {
            var data = await _carRepository.GetList(null);
            var result = new SuccessDataResult<List<Car>>(data, "Successfully");
            return result;
           
        }

        public Task<IDataResult<Car>> GetCarByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Car>>> GetListByBrandIdAsync(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Car>>> GetListByColorIdIdAsync(int colorId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
