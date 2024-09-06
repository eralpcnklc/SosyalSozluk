using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DataAccessLayer.Abstract
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
      

        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            //dışarıdan gelen entity ne ise object o olur
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            // bir dizide veya listede sadece 1 tane değer döndürmek için kullanılır
            //ornegın _writerdal.Get(x => x.WriterName) 
            return _object.SingleOrDefault(filter);

        }

        public void Insert(T p)
        {

            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            //_object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        //filtre neyse ona uygun olanları gösterir
        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {

            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
