using EVC.CrowdLanding.DomainModel;
using EVC.CrowdLanding.Service.Model;
using Microsoft.EntityFrameworkCore;
using SiemensGamesa.NAMC.StitchingTool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVC.CrowdLanding.Service
{
    public class FundingService: IFundingService
    {
        private readonly IRepository<Funding> _fundingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _userId = 1;

        public FundingService(IRepository<Funding> fundingRepository, IUnitOfWork unitOfWork)
        {
            _fundingRepository = fundingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FundingDto>> GetAll()
        {
            return await _fundingRepository
                .GetAll()
                .Select(funding => new FundingDto
                {
                    Id = funding.Id,
                    IsInvestmentRequired = funding.IsInvestmentRequired,
                    Description = funding.Description,
                    TypeOfInvestment = funding.TypeOfInvestment,
                    InvestmentCompany = funding.InvestmentCompany,
                    StartTime = funding.StartTime,
                    EndTime = funding.EndTime,
                    IsFoundedByMe = funding.UsersFundings.Any(uf => uf.UserId == _userId)
                })
                .ToListAsync();
        }

        public async Task<FundingDto> GetById(int id)
        {
            var funding = await _fundingRepository.FindByIdAsync(id, query => query.Include(a => a.UsersFundings));
            if(funding != null)
            {
                return new FundingDto
                {
                    Id = funding.Id,
                    IsInvestmentRequired = funding.IsInvestmentRequired,
                    Description = funding.Description,
                    TypeOfInvestment = funding.TypeOfInvestment,
                    InvestmentCompany = funding.InvestmentCompany,
                    StartTime = funding.StartTime,
                    EndTime = funding.EndTime,
                    IsFoundedByMe = funding.UsersFundings.Any(uf => uf.UserId == _userId)
                };
            }
            return null;
        }

        public async Task CreateUserFunding(NewFundingDto newUserFunding)
        {
            var funding = await _fundingRepository.FindByIdAsync(
                    newUserFunding.FundingId,
                    query => query.Include(a => a.UsersFundings));

            if (funding != null)
            {
                var isFoundedByMe = funding.UsersFundings.Any(uf => uf.UserId == _userId);

                if(!isFoundedByMe)
                {
                    var userFunding = new UsersFundings
                    {
                        UserId = 1,
                        Amount = newUserFunding.FundingAmount,
                        TimeOfFunding = DateTime.UtcNow
                    };

                    funding.UsersFundings.Add(userFunding);
                    _fundingRepository.SaveOrUpdate(funding);
                    await _unitOfWork.SaveChangesAsync();
                }
                // todo missing message that it is already founded by selected user
            }

            // todo missing message that funding is missing 
        }
    }
}
