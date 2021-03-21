using BookStore.DataAccess.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookStore.DataAccess.RepositoryImplementations
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {

        #region Class members

        protected readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<T> _dbset;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor: GenericRepository used to initialize the database context
        /// </summary>
        /// <param name="context"></param>
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbset = unitOfWork.Context.Set<T>();
        }

        #endregion

        #region Interface Implementation

        /// <summary>
        /// Generic GetAll method used to get all objects of a particular entity
        /// </summary>
        /// <returns>All objects of an entity</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable();
        }

        /// <summary>
        /// Generic GetById method used to find an entity using its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity</returns>
        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        /// <summary>
        /// Generic GetByExpression method used to find the entities using expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Entities</returns>
        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> expression)
        {
            var query = _dbset.Where(expression);
            return query;
        }

        /// <summary>
        /// Generic Add method to add the entity in database
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        /// <summary>
        /// Generic Add method to add the entity in database
        /// </summary>
        /// <param name="entities"></param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _unitOfWork.Context.Database.SetCommandTimeout(new TimeSpan(0, 10, 0));
            _dbset.AddRange(entities);
        }

        /// <summary>
        /// Generic delete method to delete an entity from database
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(T entity)
        {
            _dbset.Remove(entity);
        }

        /// <summary>
        /// Generic Remove Range method to delete the entities in database
        /// </summary>
        /// <param name="entities"></param>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _unitOfWork.Context.Database.SetCommandTimeout(new TimeSpan(0, 10, 0));
            _dbset.RemoveRange(entities);
        }

        /// <summary>
        /// Method: Generic edit method to update the changes in database
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Edit(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Method: Generic save method to save the changes in database
        /// </summary>
        public virtual void Save()
        {
            _unitOfWork.Context.SaveChanges();
        }

        #endregion

    }
}
