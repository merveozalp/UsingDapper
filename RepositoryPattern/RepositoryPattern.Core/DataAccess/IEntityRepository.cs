using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.DataAccess
{
    public interface  IEntityRepository<T> where T : class
    {

        Task<T> Get(int id);
        Task<List<T>> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        //void DeleteAll(T entity);
       
    }
}
