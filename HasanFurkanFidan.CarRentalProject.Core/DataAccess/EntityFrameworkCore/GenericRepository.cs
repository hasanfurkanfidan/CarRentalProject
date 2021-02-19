using HasanFurkanFidan.CarRentalProject.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HasanFurkanFidan.CarRentalProject.Core.DataAccess.EntityFrameworkCore
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new TContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new TContext();
            return await context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> expression)
        {
            using var context = new TContext();
            if (expression != null)
            {
                return await context.Set<TEntity>().Where(expression).ToListAsync();
            }
            return await context.Set<TEntity>().ToListAsync();

        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
