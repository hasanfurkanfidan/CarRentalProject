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
        public class PathStream
        {
            public FileStream Stream { get; set; }
            public string Path { get; set; }
        }
    }
}
