using EVC.CrowdLanding.DomainModel;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensGamesa.NAMC.StitchingTool.Data
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> FindByIdAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        IQueryable<T> GetAll();
        void SaveOrUpdate(T item);
    }
}
