using HasanFurkanFidan.CarRentalProject.DataAccess.Abstract;
using HasanFurkanFidan.CarRentalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.CarRentalProject.DataAccess.Concrete.Dapper
{
    public class DpBrandRepository : IBrandRepository
    {
        public Task AddAsync(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Brand entity)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> Get(Expression<Func<Brand, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<List<Brand>> GetList(Expression<Func<Brand, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
