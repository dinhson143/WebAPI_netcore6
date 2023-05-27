using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebAPI.Repository.Paging;

namespace WebAPI.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// This method gets a paged list of a generic type class.
        /// Allows filtering the returned data and includes any related data.
        /// </summary>
        /// <param name="pagingRequest">A paging request</param>
        /// <param name="predicate">A lambda expression tree for filtering data</param>
        /// <param name="includeProperties">A params of lambda expression tree for including related data</param>
        /// <returns>A paginated list of generic class type</returns>
        Task<PaginatedList<T>> GetAllAsync(PagingRequest pagingRequest, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// This method gets a generic object type class.
        /// Allows filtering the returned data and includes any related data.
        /// </summary>
        /// <param name="predicate">A lambda expression tree for filtering data</param>
        /// <param name="includeProperties">A params of lambda expression tree for including related data</param>
        /// <returns>A generic object type</returns>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// This method checks if an object exists in the DB
        /// </summary>
        /// <param name="predicate">An expression tree for filtering</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// This method adds a new entity into the DB
        /// </summary>
        /// <param name="entity">An entity to add</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> AddAsync(T entity);

        /// <summary>
        /// This method adds a list of entities into the DB
        /// </summary>
        /// <param name="entities">A list of entities to add</param>
        /// <returns></returns>
        Task AddRangeAsync(List<T> entities);

        /// <summary>
        /// This method update an existing entity in the DB
        /// </summary>
        /// <param name="entity">An entity data to edit</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> UpdateAsync(T entity);

        /// <summary>
        /// This method removes an entity from the DB.
        /// </summary>
        /// <param name="entity">Entity to be remove</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> RemoveAsync(T entity);

        /// <summary>
        /// This method removes an entity from the DB.
        /// </summary>
        /// <param name="id">Id of an entity for searching</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> RemoveAsync(int id);

        /// <summary>
        /// This method removes a list of entity from the DB
        /// </summary>
        /// <param name="entities">A list of entities to be remove</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> RemoveMultipleAsync(List<T> entities);

        /// <summary>
        /// This method updates a list of entities from the DB
        /// </summary>
        /// <param name="entities">A list of entities to be update</param>
        /// <returns>Success: true | Failure: false</returns>
        Task<bool> UpdateRangeAsync(List<T> entities);
        IQueryable<T> GetAllQueryable();

        /// <summary>
        /// This method gets a paged list of a generic type class.
        /// Allows filtering the returned data and includes any related data.
        /// </summary>
        /// <param name="pagingRequest">A paging request</param>
        /// <param name="predicate">A lambda expression tree for filtering data</param>
        /// <param name="includeProperties">A params of lambda expression tree for including related data</param>
        /// <returns>A list of generic class type</returns>
        Task<List<T>> GetAllAsyncNoPaging( Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    }
}
