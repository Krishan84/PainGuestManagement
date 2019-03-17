using PainGuestApplication.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PainGuestApplication.Model.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(int id);
        void _Add(T entity);
        void _Update(T entity);
        void _Delete(T entity);
        void _Delete(int id);
        DataServiceProcessingResult<T> Add(T entityToAdd);

        DataServiceProcessingResult<List<T>> Add(List<T> entityToAdd);

        DataServiceProcessingResult<List<T>> Get();

        DataServiceProcessingResult<T> Get(string id);

        DataServiceProcessingResult<List<T>> Get(Expression<Func<T, bool>> predicate, params string[] includes);

        DataServiceProcessingResult<List<T>> Get(Expression<Func<T, bool>> predicate);

        DataServiceProcessingResult<T> Get(T entityToFind);

        DataServiceProcessingResult<List<T>> Get(Expression<Func<T, bool>> predicate, int pageSize, int pageNumber, params string[] includes);

        DataServiceProcessingResult<List<T>> Get(Expression<Func<T, bool>> predicate, int pageSize, int pageNumber, string sortingColumn, string sortingDirection, params string[] includes);

        DataServiceProcessingResult<int> GetCount(Expression<Func<T, bool>> predicate);

        DataServiceProcessingResult<List<T2>> Get<T2>(Expression<Func<T, bool>> wherePredicate, Expression<Func<T, T2>> selectPredicate, params string[] includes);

        DataServiceProcessingResult<T> Update(T entityToUpdate);

        DataServiceProcessingResult<List<T>> Update(List<T> entitiesToUpdate);

        DataServiceProcessingResult<T> Delete(string id);

        DataServiceProcessingResult<List<T>> Delete(List<T> entitiesToDelete);
    }
}
