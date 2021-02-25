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
        public async Task<IActionResult> Add([FromForm] AddCarDto addCarDto)
        {

            var results = new List<IResult>();
            var carResult = await _carService.AddCarAsync(new Car()
            {
                BrandId = addCarDto.BrandId,
                ColorId = addCarDto.ColorId,
                DailyPrice = addCarDto.DailyPrice,
                Description = addCarDto.Description,
            });
            results.Add(carResult);
            if (addCarDto.Images.Count > 0)
            {
                foreach (var image in addCarDto.Images)
                {
                    var pathStream = AddImage(image);
                    var imageResult = _carImageService.AddImages(new CarImage()
                    {
                        CarId = carResult.Data.Id,
                        ImagePath = pathStream.Path
                    });
                    results.Add(imageResult);

                }
            }
            foreach (var item in results)
            {
                if (item.IsSuccess == false)
                {
                    return BadRequest(item);

                }
            }
            return Ok(results);
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
