using HasanFurkanFidan.CarRentalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.Entities.Concrete
{
    public class CarImage:IEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
