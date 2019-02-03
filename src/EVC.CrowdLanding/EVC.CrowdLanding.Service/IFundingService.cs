using EVC.CrowdLanding.DomainModel;
using EVC.CrowdLanding.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVC.CrowdLanding.Service
{
    public interface IFundingService
    {
        Task<List<FundingDto>> GetAll();
        Task<FundingDto> GetById(int id);
        Task CreateUserFunding(NewFundingDto newUserFunding);
    }
}
