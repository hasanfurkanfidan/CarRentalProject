using HasanFurkanFidan.CarRentalProject.Core.DataAccess.EntityFrameworkCore;
using HasanFurkanFidan.CarRentalProject.DataAccess.Abstract;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace HasanFurkanFidan.CarRentalProject.DataAccess.Concrete.EntityFrameworkCore
{
    public class BrandRepository:GenericRepository<Brand,RentalContext>,IBrandRepository
    {
    }
}
