using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.DataAccess.RepositoryInterfaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        /// <summary>
        /// Generic GetAll method used to get all objects of a particular entity
        /// </summary>
        /// <returns>All objects of entity</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Generic GetById method used to find the entity using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        T GetById(int id);

        /// <summary>
        /// Generic FindBy method used to find the entities using expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Entities</returns>
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Generic Add method to add the entity in database
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Generic Add Async method to add the entity in database
        /// </summary>
        /// <param name="entity"></param>
        Task AddAsync(T entity);

        /// <summary>
        /// Generic Add Range method to add the entities in database
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Generic delete method to delete an entity from database
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);

        /// <summary>
        /// Generic Remove Range method to delete the entities in database
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Method: Generic edit method to update the changes in database
        /// </summary>
        /// <param name="entity"></param>
        void Edit(T entity);

        /// <summary>
        /// Method: Generic save method to save the changes in database
        /// </summary>
        void Save();
    }
}
