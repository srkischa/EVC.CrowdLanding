using Microsoft.EntityFrameworkCore;

namespace EVC.CrowdLanding.Data
{
    public interface IContextSeed<TContext> where TContext : DbContext
    {
        void Seed(TContext context);
    }
}
