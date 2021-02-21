using HasanFurkanFidan.CarRentalProject.Api.Models;
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
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(Car car)
        {
            var result = await _carService.AddCarAsync(car);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
            var result =  await _carService.DeleteAsync(car);
            return Ok(result);
        }
        [HttpPost("removelist")]
        public async Task<IActionResult>RemoveList(CarRemoveRangeIdsModel model)
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
