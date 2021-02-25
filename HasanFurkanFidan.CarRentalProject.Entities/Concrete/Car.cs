using HasanFurkanFidan.CarRentalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public string ModelYear { get; set; }
        public string Description { get; set; }
        public decimal DailyPrice { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Color Color { get; set; }
        public int ColorId { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
