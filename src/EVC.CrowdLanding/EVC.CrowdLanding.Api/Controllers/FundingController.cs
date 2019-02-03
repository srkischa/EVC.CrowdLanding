using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EVC.CrowdLanding.Api.Model;
using EVC.CrowdLanding.DomainModel;
using EVC.CrowdLanding.Service;
using EVC.CrowdLanding.Service.Model;
using Microsoft.AspNetCore.Mvc;

namespace EVC.CrowdLanding.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundingController : ControllerBase
    {
        private readonly IFundingService _fundingService;

        public FundingController(IFundingService fundingService)
        {
            _fundingService = fundingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FundingResponse>>> Get()
        {
            var fundings = await _fundingService.GetAll();
            return fundings.Select(f => new FundingResponse
            {
                Id = f.Id,
                InvestmentStatus = f.IsFoundedByMe ? "Already Founded" : "Investment required",
                Description = f.Description,
                TypeOfInvestment = f.TypeOfInvestment,
                InvestmentCompany = f.InvestmentCompany,
                StartTime = f.StartTime.ToShortDateString(),
                EndTime = f.EndTime.ToShortDateString(),
                IsFoundedByMe = f.IsFoundedByMe
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FundingResponse>> Get(int id)
        {
            var funding = await _fundingService.GetById(id);
            if (funding != null)
            {
                return new FundingResponse
                {
                    Id = funding.Id,
                    InvestmentStatus = funding.IsFoundedByMe ? "Already Founded" : "Investment required",
                    Description = funding.Description,
                    TypeOfInvestment = funding.TypeOfInvestment,
                    InvestmentCompany = funding.InvestmentCompany,
                    StartTime = funding.StartTime.ToShortDateString(),
                    EndTime = funding.EndTime.ToShortDateString(),
                    IsFoundedByMe = funding.IsFoundedByMe
                };
            }

            return NotFound();
        }

        [HttpPost]
        public async Task Post([FromBody] NewFundingDto value)
        {
            await _fundingService.CreateUserFunding(value);
        }
    }
}
