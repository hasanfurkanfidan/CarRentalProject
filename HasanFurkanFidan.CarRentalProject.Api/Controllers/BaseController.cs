using HasanFurkanFidan.CarRentalProject.Core.Utilities.BusinessRules;
using HasanFurkanFidan.CarRentalProject.Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.CarRentalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public PathStream AddImage(IFormFile file)
        {
            var rule = BusinessRule.Run(ExtentionRule(file));
            if (rule == null)
            {
                var array = file.FileName.Split(".");
                array[1] = "webp";
                var imageName = Guid.NewGuid() + Path.GetExtension(array[0] + "." + array[1]);
                var path = Directory.GetCurrentDirectory() + "/wwwroot/img/Car/" + imageName;
                var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                return new PathStream
                {
                    Path = "/img/Car/" + imageName,
                    Stream = stream
                };
            }
            return new PathStream
            {
                Message = "Path Error"
            };
        }
        public class PathStream
        {
            public FileStream Stream { get; set; }
            public string Path { get; set; }
            public string Message { get; set; }
        }
        private IResult ExtentionRule(IFormFile file)
        {
            var extention = Path.GetExtension(file.FileName);
            if (extention == ".png" || extention == ".jpg" || extention == ".jpeg")
            {
                return new SuccessResult();
            }
            return new ErrorResult("Extention Error");
        }
    }
}
