using ExaminantionSystem_R3.Models;
using ExaminationSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ExaminantionSystem_R3.Repositories
{
    public class GeneralRepository<T> where T : BaseModel, new()
    {
        protected Context _context;
        protected DbSet<T> _dbSet;
        public GeneralRepository()
        {
            _context = new Context();
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public IQueryable<T> GetById(int id)
        {
            return _dbSet.Where(x => x.ID == id);
        }
       
        public bool Add(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges() > 0;
        }
        public async Task<bool> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public bool Update(T entity, params string[] modifiedProperties)
        {
            if (!_dbSet.Any(x => x.ID == entity.ID))
            {
               return false;
            }
            var local = _dbSet.Local.FirstOrDefault(x => x.ID == entity.ID);
            EntityEntry entityEntry;
            if (local is null)
            {
                entityEntry = _context.Entry(entity);
            }
            else
            {
                entityEntry = _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.ID == entity.ID);
            }
            foreach (var property in entityEntry.Properties)
            {
                if (modifiedProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }

            }
            return _context.SaveChanges() > 0;

        }
        public async Task<bool> UpdateAsync(T entity, params string[] modifiedProperties)
        {
            if (!_dbSet.Any(x => x.ID == entity.ID))
            {
                return false;
            }
            var local = _dbSet.Local.FirstOrDefault(x => x.ID == entity.ID);
            EntityEntry entityEntry;
            if (local is null)
            {
                entityEntry = _context.Entry(entity);
            }
            else
            {
                entityEntry = _context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.ID == entity.ID);
            }
            foreach (var property in entityEntry.Properties)
            {
                if (modifiedProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }

            }
            return await _context.SaveChangesAsync() > 0;

        }
        public bool Delete(int id)
        {
            T entity = new T() { ID = id };
            entity.isDeleted = true;
            return Update(entity, nameof(entity.isDeleted));
        }
        public async Task<bool> DeleteAsync(int id)
        {
            T entity = new T() { ID = id };
            entity.isDeleted = true;
            return Update(entity, nameof(entity.isDeleted));

            //T q = await _dbSet.Where(x => x.ID == id).AsTracking().FirstOrDefaultAsync();
            //q.isDeleted = true;
            // _dbSet.Update(q);
            return await _context.SaveChangesAsync() > 0;

        }

        internal bool Add(object course)
        {
            throw new NotImplementedException();
        }
    }
}
