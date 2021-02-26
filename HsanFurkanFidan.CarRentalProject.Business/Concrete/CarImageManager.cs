using HasanFurkanFidan.CarRentalProject.Core.Utilities.BusinessRules;
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
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageRepository _carImageRepository;
        public CarImageManager(ICarImageRepository carImageRepository)
        {

            _carImageRepository = carImageRepository;
        }

        public async Task<IResult> AddImageAsync(CarImage carImage)
        {
            var result = BusinessRule.Run(await MoreThanFiveImageRule(carImage.CarId));
            if (result==null)
            {
                return new SuccessResult("Ekleme işlemi başarılı");
            }
            return new ErrorResult(result.Message);
        }

        public Task<IDataResult<List<CarImage>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<List<CarImage>>> GetImagesWithCarId(int carId)
        {
            var data = await _carImageRepository.GetList(p => p.CarId == carId);
            return new SuccessDataResult<List<CarImage>>(data);
        }

        public Task<IDataResult<List<CarImage>>> GetListByCarIdAsync(int carId)
        {
            throw new NotImplementedException();
        }
        private async Task<IResult> MoreThanFiveImageRule(int carId)
        {
            var data = await GetImagesWithCarId(carId);
            if (data.Data.Count > 5)
            {
                return new ErrorResult("Hata");
            }
            return new SuccessResult();
        }

    }
}
