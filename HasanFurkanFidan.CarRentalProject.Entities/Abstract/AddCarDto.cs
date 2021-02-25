using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Entities.Abstract
{
    public class AddCarDto
    {
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
