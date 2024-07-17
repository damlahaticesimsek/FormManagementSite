using Microsoft.EntityFrameworkCore;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly FormManagementContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(FormManagementContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Insert(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        T entity = _dbSet.Find(id);
        _dbSet.Remove(entity);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
