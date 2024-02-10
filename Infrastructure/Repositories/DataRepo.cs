using Infrastructure.Contexts;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class DataRepo<TEntity>(ApplicationDataContext context) where TEntity : class
{
    private readonly ApplicationDataContext _context = context;

    // Create
    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            Console.WriteLine("DbUpdateException: " + ex.InnerException?.Message);
        }
        return null!;
    }
  
    // Read
    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression) 
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            return entity!;
        } 
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            Console.WriteLine("DbUpdateException: " + ex.InnerException?.Message);
        }
        return null!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            Console.WriteLine("DbUpdateException: " + ex.InnerException?.Message);
        }
        return Enumerable.Empty<TEntity>();        
    }

    // Update
    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
            _context.SaveChanges();

            return entityToUpdate!;
        }

        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            Console.WriteLine("DbUpdateException: " + ex.InnerException?.Message);
        }
        return null!;
    }

    // Delete
    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            _context.Remove(entity!);
            _context.SaveChanges();
            //  return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            Console.WriteLine("DbUpdateException: " + ex.InnerException?.Message);
        }

    }

    // Exists
}
