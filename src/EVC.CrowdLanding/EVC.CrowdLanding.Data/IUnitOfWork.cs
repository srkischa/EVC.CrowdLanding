using System.Threading.Tasks;

namespace SiemensGamesa.NAMC.StitchingTool.Data
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
