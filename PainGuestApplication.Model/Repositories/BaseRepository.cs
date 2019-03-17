using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PainGuestApplication.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using PainGuestApplication.Model;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PainGuestApplication.Model.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public IConfiguration Configuration { get; set; }
        protected readonly UserIdentityDbContext _context;
        protected DbSet<TEntity> DbSet { get; set; }
        public BaseRepository(UserIdentityDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("dbContext");
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual DataServiceProcessingResult<TEntity> Add(TEntity entityToAdd)
        {
            var result = new DataServiceProcessingResult<TEntity>() { Success = false, Data = null };
            try
            {
                _context.Add(entityToAdd);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorDescription = string.Format("Could not add the entity into database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorDescription);
                return result;
            }
            result.Success = true;
            result.Data = entityToAdd;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Add(List<TEntity> entityToAdd)
        {
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            try
            {
                foreach (var entity in entityToAdd)
                {
                    _context.Add(entity);
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not add entities into the database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Success = true;
            result.Data = entityToAdd;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Get()
        {
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not update the Entities into database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Data = DbSet.ToList();
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<TEntity> Get(string id)
        {
            TEntity entity;
            var result = new DataServiceProcessingResult<TEntity>() { Success = false, Data = null };
            try
            {
                entity = _context.Find<TEntity>(id);
                if (entity == null)
                {
                    return result;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorDescription = string.Format("Could not get entities from database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorDescription);
                return result;
            }
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, params string[] includes)
        {
            var entities = new List<TEntity>();
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            try
            {
                entities = DbSet.IncludeMany(includes).Where(predicate).ToList();
                if (entities == null)
                {
                    return result;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not get the entities from database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Data = entities;
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = new List<TEntity>();
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            try
            {
                entities = DbSet.Where(predicate).ToList();
                if (entities == null)
                {
                    return result;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not fetch the entities from database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Data = entities;
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<TEntity> Get(TEntity entityToFind)
        {
            TEntity entity;
            var result = new DataServiceProcessingResult<TEntity>() { Success = false, Data = null };
            try
            {
                entity = _context.Find<TEntity>(entityToFind);
                if (entity == null)
                {
                    return result;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not fetch the entities into database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Data = entity;
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageNumber, params string[] includes)
        {
            var entities = new List<TEntity>();
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            try
            {
                entities = DbSet.IncludeMany(includes).Where(predicate).Skip((pageNumber) * pageSize).Take(pageSize).ToList();
                if (entities == null)
                {
                    return result;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not get the entities from database.");
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Data = entities;
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, int pageSize, int pageNumber, string sortingColumn, string sortingDirection, params string[] includes)
        {
            var entities = new List<TEntity>();
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            try
            {
                var queryPredicate = DbSet.IncludeMany(includes).Where(predicate);

                PropertyInfo property = !string.IsNullOrEmpty(sortingColumn) ? typeof(TEntity).GetProperty(sortingColumn, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase) : null;
                if (string.IsNullOrEmpty(sortingDirection) && property != null)
                {
                    if (sortingDirection == "asc")
                    {
                        queryPredicate = queryPredicate.OrderBy(o => property.GetValue(o, null));
                    }
                    else if (sortingDirection == "desc")
                    {
                        queryPredicate = queryPredicate.OrderByDescending(o => property.GetValue(o, null));
                    }

                }
                entities = queryPredicate.Skip((pageNumber) * pageSize).Take(pageSize).ToList();
                if (entities == null)
                {
                    return result;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorDescription = string.Format("Could not fetch the entities from database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorDescription);
                return result;
            }
            result.Data = entities;
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<int> GetCount(Expression<Func<TEntity, bool>> predicate)
        {
            int count = 0;
            var result = new DataServiceProcessingResult<int>() { Success = false };
            try
            {
                count = DbSet.Where(predicate).ToList().Count;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not fetch the count from the database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Data = count;
            result.Success = true;
            return result;
        }


        public virtual DataServiceProcessingResult<TEntity> Update(TEntity entityToUpdate)
        {
            var result = new DataServiceProcessingResult<TEntity>() { Success = false, Data = null };
            try
            {
                _context.Update(entityToUpdate);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not update the entities into database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Success = true;
            result.Data = entityToUpdate;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Update(List<TEntity> entitiesToUpdate)
        {
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            try
            {
                _context.UpdateRange(entitiesToUpdate);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorDescription = string.Format("Could not update the entities into database.Exceotion Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorDescription);
                return result;
            }
            result.Success = true;
            result.Data = entitiesToUpdate;
            return result;
        }

        public virtual DataServiceProcessingResult<TEntity> Delete(string id)
        {
            var result = new DataServiceProcessingResult<TEntity>() { Success = false, Data = null };
            var existingEntityResult = this.Get(id);
            if (!existingEntityResult.Success)
            {
                return result;
            }
            try
            {
                _context.Remove<TEntity>(existingEntityResult.Data);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorDescription = string.Format("Could not remove the entity from database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorDescription);
                return result;
            }
            result.Success = true;
            return result;
        }

        public virtual DataServiceProcessingResult<List<TEntity>> Delete(List<TEntity> entitiesToDelete)
        {
            var result = new DataServiceProcessingResult<List<TEntity>>() { Success = false, Data = null };
            var markedToDelete = new List<TEntity>();
            var failedToDelete = new List<TEntity>();
            foreach (var entity in entitiesToDelete)
            {
                var existingEntityResult = this.Get(entity);
                if (!existingEntityResult.Success)
                {
                    failedToDelete.Add(entity);
                }
                markedToDelete.Add(entity);
            }
            if (failedToDelete.Count > 0)
            {
                result.Success = false;
                result.Data = failedToDelete;
                return result;
            }
            try
            {
                _context.RemoveRange(markedToDelete);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not remove the entities from database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Success = true;
            result.Data = markedToDelete;
            return result;
        }

        public virtual DataServiceProcessingResult<List<T2>> Get<T2>(Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, T2>> selectPredicate, params string[] includes)
        {
            var entities = new List<T2>();
            var result = new DataServiceProcessingResult<List<T2>>() { Success = false, Data = null };
            try
            {
                entities = DbSet.IncludeMany(includes).Where(wherePredicate).Select(selectPredicate).ToList();
                if (entities == null)
                {
                    return result;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                var errorMessage = string.Format("Could not fetch the entities from database.Exception Details:{0}", e.Message);
                result.Error = new ProcessingError("1", "", null, adminMessage: errorMessage);
                return result;
            }
            result.Success = true;
            result.Data = entities;
            return result;
        }

        public  virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void _Add(TEntity entity)
        {
            var dbEntityEntry = _context.Entry(entity);
            if (dbEntityEntry.State!=(EntityState)EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void _Update(TEntity entity)
        {
            var dbEntityEntry = _context.Entry(entity);
            if (dbEntityEntry.State != (EntityState)EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void _Delete(TEntity entity)
        {
            var dbEntityEntry = _context.Entry(entity);
            if (dbEntityEntry.State != (EntityState)EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
            
        }

        public virtual void _Delete(int id)
        {
            var entity = GetById(id);
            if (entity==null) return;
            _Delete(entity);
        }
    }
}
