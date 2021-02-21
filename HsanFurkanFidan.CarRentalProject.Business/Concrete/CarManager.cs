using FluentValidation;
using HasanFurkanFidan.CarRentalProject.Core.Aspects.Autofac.Validation;
using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using HasanFurkanFidan.CarRentalProject.DataAccess.Abstract;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using HsanFurkanFidan.CarRentalProject.Business.Abstract;
using HsanFurkanFidan.CarRentalProject.Business.ValidationRules;
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
        [ValidationAspect(typeof(CarValidator))]
        public async Task< IResult> AddCarAsync(Car car)
        {
            await _carRepository.AddAsync(car);
            return new SuccessResult() { Message = "Car Added Successfully" };
        }

        public async Task<IResult> DeleteAsync(Car car)
        {
            var result = _carRepository.DeleteAsync(car);
            return new SuccessResult() { Message = "Deleted Successfully" };
        }

        public async Task<IDataResult<List<Car>>> GetAllCarsAsync()
        {
            var data = await _carRepository.GetList(null);
            var result = new SuccessDataResult<List<Car>>(data, "Successfully");
            return result;

        }

        public async Task<IDataResult<Car>> GetCarByIdAsync(int id)
        {
            var data = await _carRepository.Get(p => p.Id == id);
            var result = new SuccessDataResult<Car>(data, "Successfully");
            return result;
        }

        public Task<IDataResult<List<Car>>> GetListByBrandIdAsync(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Car>>> GetListByColorIdIdAsync(int colorId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RemoveRangeAsync(List<Car> cars)
        {
            await _carRepository.DeleteList(cars);
            var result = new SuccessResult()
            {
                Message = "List Deleted Successfully"
            };
            return result;
        }

        public Task<IResult> UpdateAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}
