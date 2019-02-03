using EVC.CrowdLanding.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensGamesa.NAMC.StitchingTool.Data
{
    public class Repository<T> : IRepository<T> where T :  Entity
    {
        private readonly DbContext _context;

        protected DbSet<T> DbSet { get; }

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            DbSet = context.Set<T>();
        }

        public async Task<T> FindByIdAsync(
            int id, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = DbSet;
            if(include != null)
            {
                query = include(query);
            }

            return await query.FirstAsync(x => x.Id == id);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void SaveOrUpdate(T item)
        {
            if (item.Id == 0)
            {
                DbSet.Add(item);
            }
            else
            {
                _context.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
