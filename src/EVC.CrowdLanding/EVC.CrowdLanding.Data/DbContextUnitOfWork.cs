using EVC.CrowdLanding.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensGamesa.NAMC.StitchingTool.Data
{

    public class DbContextUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public DbContextUnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
