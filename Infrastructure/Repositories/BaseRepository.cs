using Infrastructure.Contexts;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;

    // Create
    public virtual TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    // Read
    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression) // Han har exppression i stället för predicate
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        return entity!; 
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    // Update
    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity); // Ta bort ! vid null check.
        _context.SaveChanges();

        return entityToUpdate!;
    }

    // Delete
    //  public bool Delete(Expression<Func<TEntity, bool>> expression) För när jag gör det med komplicerat.
    public virtual void Delete(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entity!);
        _context.SaveChanges();
      //  return true;
    }

    // Exists
}
