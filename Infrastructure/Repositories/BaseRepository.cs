using Infrastructure.Contexts;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        // Create
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                await _context.SaveChangesAsync(); 

                return entity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return null!;
            }
        }

        public virtual TEntity Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        // Read
        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            return entity!;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
                if (entity != null) 
                    return entity!;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null!;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var result = await _context.Set<TEntity>().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return null!;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        // Update
        public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return entityToUpdate!;
        }

        public async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
        {
            try
            {
                var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

                if (entityToUpdate != null)
                {
                    _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                    await _context.SaveChangesAsync();
                }

                return entityToUpdate!;
            }
            catch (Exception ex) { Debug.WriteLine($"Error occurred during update: {ex.Message}"); }
            return null!;
        }


        // Delete
        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Remove(entity!);
            _context.SaveChanges();
        }

        public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

                if (entity != null)
                {
                    _context.Remove(entity!);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else { Debug.WriteLine("Entity not found for deletion."); }
            }
            catch (Exception ex) { Debug.WriteLine($"Exception during deletion: {ex.Message}"); }

            return false;
        }

    }
}
