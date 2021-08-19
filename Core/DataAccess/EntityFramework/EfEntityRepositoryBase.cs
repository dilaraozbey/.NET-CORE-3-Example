using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRespositoryBase<TEntitiy, TContext> : IEntityRepository<TEntitiy>
     where TEntitiy : class, IEntity, new()
       where TContext : DbContext, new()

    {
        public void Update(TEntitiy entity)
        {
            //using disposable pattern (nesnenin hayatını using içinde başlayıp bitmeye bağlıyoruz)
            using (var context = new TContext())
            {
                //Gönderilen entityi contexte ekledik
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }

        }
        public void Add(TEntitiy entity)
        {
            using (var context = new TContext())
            {
                //Gönderilen entityi contexte ekledik
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(TEntitiy entity)
        {

            using (var context = new TContext())
            {
                //Gönderilen entityi contexte ekledik
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }

        }

        public TEntitiy Get(Expression<Func<TEntitiy, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntitiy>().SingleOrDefault(filter);
            }
        }

        public IList<TEntitiy> GetList(Expression<Func<TEntitiy, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntitiy>().ToList()
                    : context.Set<TEntitiy>().Where(filter).ToList();

            }


        }

       
    }
}
