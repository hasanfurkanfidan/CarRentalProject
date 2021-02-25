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
        private readonly ICarService _carService;
        public CarImageManager(ICarImageRepository carImageRepository,ICarService carService)
        {
            _carImageRepository = carImageRepository;
            _carService = carService;
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageRepository.GetList(null).Result);
        }

        public IDataResult<List<CarImage>> GetListByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageRepository.GetList(p => p.CarId == carId).Result);
        }
        public IResult AddImages(CarImage carImage)
        {
            var result =  BusinessRule.Run(ImageLimit(carImage).Result);
            if (result.IsSuccess)
            {
                _carImageRepository.AddAsync(carImage).Wait();
                return new SuccessResult()
                {
                    Message = "Başarılı"
                };
            }
            return new ErrorResult();
        }
        public async Task<IResult> ImageLimit(CarImage carImage)
        {
            var car = await _carService.GetCarByIdAsync(carImage.CarId);
            var carImages = GetListByCarId(car.Data.Id);
            if (carImages.Data.Count>0)
            {
                return new ErrorResult()
                {
                    Message = "5 resimden fazla resim koymak yasaktır"
                };
            }
            return new SuccessResult();
        }
    }
}
