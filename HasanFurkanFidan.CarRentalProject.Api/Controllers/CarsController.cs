using HasanFurkanFidan.CarRentalProject.Api.Models;
using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using HasanFurkanFidan.CarRentalProject.Entities.Abstract;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using HsanFurkanFidan.CarRentalProject.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.CarRentalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        private readonly ICarService _carService;
        private readonly ICarImageService _carImageService;
        public CarsController(ICarService carService, ICarImageService carImageService)
        {
            _carImageService = carImageService;
            _carService = carService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddCarDto addCarDto)
        { 
            var car = new Car()
            {
                BrandId = addCarDto.BrandId,
                ColorId = addCarDto.ColorId,
                DailyPrice = addCarDto.DailyPrice,
                ModelYear = addCarDto.ModelYear,
                Description = addCarDto.Description,
            };
            var carResult = await _carService.AddCarAsync(car);
            if (carResult.IsSuccess)
            {
                var carImageResult = await _carImageService.AddImageAsync(new CarImage()
                {
                    CarId = car.Id,
                    ImagePath = "/img/Car/index.jpg"
                });
                if (carImageResult.IsSuccess)
                {
                    return Ok(new SuccessResult() { Message = "Ekleme işlemi başarılı" });
                }
                else
                {
                    return BadRequest(new ErrorResult() { Message = "Resim eklerken hata oluştu" });
                }
            }
            return Ok(carResult);

        }
        [HttpGet("allcars")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carService.GetAllCarsAsync();
            return Ok(result);
        }
        [HttpPost("remove")]
        public async Task<IActionResult> Remove(int carId)
        {
            var carResult = await _carService.GetCarByIdAsync(carId);
            var car = carResult.Data;
            var result = await _carService.DeleteAsync(car);
            return Ok(result);
        }
        [HttpPost("removelist")]
        public async Task<IActionResult> RemoveList(CarRemoveRangeIdsModel model)
        {
            List<Car> cars = new List<Car>();
            foreach (var id in model.CarIds)
            {
                var carResult = await _carService.GetCarByIdAsync(id);
                var car = carResult.Data;
                if (carResult.IsSuccess)
                {
                    cars.Add(car);
                }
            }
            var result = await _carService.RemoveRangeAsync(cars);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
