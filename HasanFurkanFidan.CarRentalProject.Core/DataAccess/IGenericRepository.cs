using HasanFurkanFidan.CarRentalProject.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.CarRentalProject.Core.DataAccess
{
    public interface IGenericRepository<TEntity> where TEntity:class,IEntity,new()
    {
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        Task DeleteList(List<TEntity> entities);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);

    }
}
