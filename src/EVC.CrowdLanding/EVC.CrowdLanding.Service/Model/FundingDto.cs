using System;

namespace EVC.CrowdLanding.Service.Model
{
    public class FundingDto
    {
        public int Id { get; set; }

        public bool IsInvestmentRequired { get; set; }

        public string Description { get; set; }

        public string TypeOfInvestment { get; set; }

        public string InvestmentCompany { get; set; }

        public bool IsFoundedByMe { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
