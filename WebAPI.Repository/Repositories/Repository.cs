using WebAPI.Repository.Interfaces;
using WebAPI.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebAPI.Repository.EF;
using WebAPI.Repository.Constants;

namespace WebAPI.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MyContext Context;
        protected readonly ILogger<Repository<T>> Logger;

        public Repository(
            MyContext context,
            ILogger<Repository<T>> logger)
        {
            Context = context;
            Logger = logger;
        }

        public async Task<PaginatedList<T>> GetAllAsync(PagingRequest pagingRequest, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (includeProperties != null)
                {
                    query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
                }

                return await PaginatedList<T>.ToPaginatedListAsync(query.AsNoTracking(), pagingRequest.PageNumber, pagingRequest.PageSize);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", StatusRequest.ErrorOccurred, nameof(GetAllAsync));
                throw;
            }
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                var result = await Context.AddAsync(entity);
                return result.State is EntityState.Added;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} in {1}", StatusRequest.AddFailure, nameof(AddAsync));
                throw;
            }
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            try
            {
                await Context.AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} in {1}", StatusRequest.AddRangeFailure, nameof(AddRangeAsync));
                throw;
            }

        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();

                if (includeProperties != null)
                {
                    query = includeProperties.Aggregate(
                        query,
                        (current, includeProperty) => current.Include(includeProperty)); // chua hieu lam 
                }

                return await query.AsNoTracking().SingleOrDefaultAsync(predicate);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", StatusRequest.GetDataFailed, nameof(GetAsync));
                throw;
            }
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            try
            {
                var result = Context.Set<T>().Remove(entity);
                return await Task.FromResult(result.State is EntityState.Deleted);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} in {1}", StatusRequest.DeleteFailure, nameof(RemoveAsync));
                throw;
            }
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveMultipleAsync(List<T> entities)
        {
            try
            {
                Context.Set<T>().RemoveRange(entities);
                foreach (var entity in entities)
                {
                    var result = Context.Entry(entity).State is EntityState.Deleted;
                    if (result is false)
                        return await Task.FromResult(false);
                }

                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", StatusRequest.UpdateFailure, nameof(UpdateRangeAsync));
                throw;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                var result = Context.Set<T>().Update(entity);
                return await Task.FromResult(result.State is EntityState.Modified);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} in {1}", StatusRequest.UpdateFailure, nameof(UpdateAsync));
                throw;
            }
        }

        public async Task<bool> UpdateRangeAsync(List<T> entities)
        {
            try
            {
                Context.Set<T>().UpdateRange(entities);

                foreach (var entity in entities)
                {
                    var result = Context.Entry(entity).State is EntityState.Modified;
                    if (result is false)
                        return await Task.FromResult(false);
                }

                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", StatusRequest.UpdateFailure, nameof(UpdateRangeAsync));
                throw;
            }
        }

        public IQueryable<T> GetAllQueryable()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();
                var result = await query.AsNoTracking()
                    .SingleOrDefaultAsync(predicate);
                return (result != null);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} in {1}", StatusRequest.ErrorOccurred, nameof(ExistsAsync));
                throw;
            }
        }

        public async Task<List<T>> GetAllAsyncNoPaging(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = Context.Set<T>();

                if (predicate != null)
                {
                    query = query.Where(predicate);
                }

                if (includeProperties != null)
                {
                    query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
                }

                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "{0} {1}", StatusRequest.ErrorOccurred, nameof(GetAllAsync));
                throw;
            }
        }
    }
}
