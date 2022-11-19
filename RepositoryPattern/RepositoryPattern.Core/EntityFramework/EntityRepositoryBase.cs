using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryPattern.Core.EntityFramework
{


    public  class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using(var context = new TContext())
            {
                var AddEntity = context.Entry(entity);   // Abone edilen nesne
                AddEntity.State = EntityState.Added;   // AddEntity için state içerisinden yapmak istediğimiz methodu atamış oluyoruz.
                context.SaveChanges(); // Veritabanına değişikliği kaydettik.
            }
        }

        public void Delete(int id)
        {
            using(var context =new TContext())
            {
                context.Remove(id);
                context.SaveChanges() ;

            }
        }

        public Task<TEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        //--------------------------------------------------------------------------------
        //public void DeleteAll(TEntity entity)
        //{
        //  using  (var context = new TContext())
        //    {
        //        TEntity exisData = context.Set<TEntity>().Find(entity);
        //        if (exisData !=null)
        //        {
        //            context.Set<TEntity>().Remove(exisData);
        //            context.SaveChanges();
        //        }
        //    }

        //}
        //--------------------------------------------------------------------------------

        //public async Task<TEntity> Get(int id)
        //{
        //    using(var context = new TContext())
        //    {
        //        return await context.Set;
        //    }
        //}

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter is null ? 
                    await context.Set<TEntity>().ToListAsync() :
                    await context.Set<TEntity>().
                    Where(filter).ToListAsync();

            }
        }



        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var UpdateEntity = context.Entry(entity);
                UpdateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
