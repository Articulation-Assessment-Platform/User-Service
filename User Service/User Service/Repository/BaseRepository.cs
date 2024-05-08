namespace User_Service.Repository
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using User_Service.Data;
    using User_Service.Repository.Interfaces;

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class 

    {
        protected readonly UserContext _context;

        public BaseRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }

}
