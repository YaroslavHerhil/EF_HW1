using EF_HW1.DLL.Modules;
using Microsoft.EntityFrameworkCore;

namespace EF_HW1.DLL
{
    public class Repository<TEntity>  where TEntity : class
    {
        private Context _context;
        public Repository() { _context = new Context(); }

        public DbSet<TEntity> GetEntity()
        {
            return _context.Set<TEntity>();
        }
        public void AddEntity(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
        public void UpdateEntity(TEntity entity) 
        { 
            _context.Set<TEntity>().Update(entity); 
            _context.SaveChanges();
        }
        public void RemoveEntity(TEntity entity) 
        { 
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges(); 
        }

    }
}
