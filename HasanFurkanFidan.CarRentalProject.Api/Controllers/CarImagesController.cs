using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
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
    public class CarImagesController : BaseController
    {
        private readonly ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCarImage([FromForm]IFormFile file, int carId)
        {
            var pathStream = AddImage(file);
            if (pathStream.Message == null)
            {
                var result = await _carImageService.AddImageAsync(new CarImage
                {
                    CarId = carId,
                    ImagePath = pathStream.Path,
                });
                if (result.IsSuccess)
                {
                    return Ok(new SuccessResult()
                    {
                        Message = "Başarılı Resim Eklemesi"
                    });
                }
                return BadRequest(result.Message);

            }
            return BadRequest(pathStream.Message);
        }
    }
}
