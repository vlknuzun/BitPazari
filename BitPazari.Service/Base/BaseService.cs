using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BitPazari.Core.Entity;
using BitPazari.Core.Entity.Enum;
using BitPazari.Core.Service;
using BitPazari.Model.Context;
using BitPazari.Service.Tools;

namespace BitPazari.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {

        ProjectContext _context = SingletonContext.DbInstance as ProjectContext;


        public void Add(T item)
        {
            item.Status = Status.Active;
            _context.Set<T>().Add(item);
            Save();
        }

        public void Add(IEnumerable<T> item)
        {
            _context.Set<T>().AddRange(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> expression) => _context.Set<T>().Any(expression);

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status == Status.Active).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public void Remove(T item)
        {
            item.Status = Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> expression)
        {
            foreach (var item in GetDefault(expression))
            {
                item.Status = Status.Deleted;
                Update(item);
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T item)
        {
            T updated = GetById(item.Id);
            DbEntityEntry entry = _context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Save();
        }
        //singleton pattern kullanılıdığında ef cache sorunu yaratıyor bunu engellemek adına kullanıyoruz aşağıdaki metodu
        public void DetachEntity(T item)
        {
            _context.Entry<T>(item).State = EntityState.Detached;
        }
    }
}
