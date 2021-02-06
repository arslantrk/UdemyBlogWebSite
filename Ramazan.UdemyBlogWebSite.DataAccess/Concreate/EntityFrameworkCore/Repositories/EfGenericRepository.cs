using Microsoft.EntityFrameworkCore;
using Ramazan.UdemyBlogWebSite.DataAccess.Concreate.EntityFrameworkCore.Context;
using Ramazan.UdemyBlogWebSite.DataAccess.Interfaces;
using Ramazan.UdemyBlogWebSite.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ramazan.UdemyBlogWebSite.DataAccess.Concreate.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new UdemyBlogWebSiteContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new UdemyBlogWebSiteContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(int Id)
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.FindAsync<TEntity>(Id);

        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter,Expression<Func<TEntity,TKey>> keySelector)//Sort edilmiş hali
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)//Sort edilmiş hali
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new UdemyBlogWebSiteContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new UdemyBlogWebSiteContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
