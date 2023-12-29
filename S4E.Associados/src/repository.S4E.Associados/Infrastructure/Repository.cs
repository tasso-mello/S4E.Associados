namespace repository.S4E.Associados.Infrastructure
{
    using entities.S4E.Associados;
    using Microsoft.EntityFrameworkCore;
    using repository.S4E.Associados.Context;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task Create(IEnumerable<T> entity);
        Task<T> ReadOne(Expression<Func<T, bool>> where, List<string>? includes = null);
        Task<IEnumerable<T>> Read();
        Task<IEnumerable<T>> Read(List<string>? includes = null);
        Task<IEnumerable<T>> Read(int skip, int take, List<string>? includes = null);
        Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, List<string>? includes = null);
        Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, int skip, int take, List<string>? includes = null);
        Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, int skip, int take, List<string>? includes = null);
        Task<IEnumerable<T>> Read(Expression<Func<T, object>> orderby, int skip, int take, List<string>? includes = null);
        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> where);
        Task<bool> Exists(Expression<Func<T, bool>> where);
        Task<T> Update(T entity);
        Task Update(IEnumerable<T> entity);
        Task Delete(long id);
        Task Delete(T entity);
        Task Delete(Expression<Func<T, bool>> where);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual async Task<T> Create(T entity)
        {
            var saved = await _dbSet.AddAsync(entity);
            _dbContext.Entry(entity).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return saved.Entity;
        }
        public virtual async Task Create(IEnumerable<T> entity)
        {
            await _dbSet.AddRangeAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<IEnumerable<T>> Read() => await _dbSet.ToListAsync();
        public virtual async Task<IEnumerable<T>> Read(List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Read(int skip, int take, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Skip((skip - 1) * take).Take(take);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Where(where);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<T> ReadOne(Expression<Func<T, bool>> where, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Where(where);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.FirstOrDefaultAsync();
        }
        public virtual async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, int skip, int take, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Where(where).Skip((skip - 1) * take).Take(take);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderby, int skip, int take, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).Where(where).OrderBy(orderby).Skip((skip - 1) * take).Take(take);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> Read(Expression<Func<T, object>> orderby, int skip, int take, List<string>? includes = null)
        {
            var query = _dbSet.Select(c => c).OrderBy(orderby).Skip((skip - 1) * take).Take(take);

            if (includes != null)
                includes.ForEach(include => query = query.Include(include));

            return await query.ToListAsync();
        }
        public virtual async Task<int> Count()
            => await _dbSet.CountAsync();
        public virtual async Task<int> Count(Expression<Func<T, bool>> where)
             => await _dbSet.Where(where).CountAsync();
        public virtual async Task<bool> Exists(Expression<Func<T, bool>> where)
            => await _dbSet.AnyAsync(where);
        public virtual async Task<T> Update(T entity)
        {
            var updated = _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return updated.Entity;
        }
        public virtual async Task Update(IEnumerable<T> entity)
        {
            _dbSet.AttachRange(entity);
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task Delete(long id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
            await _dbContext.SaveChangesAsync();
        }
        public virtual async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }        
        public virtual async Task Delete(Expression<Func<T, bool>> where)
        {
            var entitiesToDelete = await _dbSet.Where(where).ToListAsync();

            if (entitiesToDelete.Any())
            {
                _dbSet.RemoveRange(entitiesToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}