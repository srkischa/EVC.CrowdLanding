namespace EVC.CrowdLanding.Api.Model
{
    public class FundingResponse
    {
        public int Id { get; set; }

        public string InvestmentStatus { get; set; }

        public string Description { get; set; }

        public string TypeOfInvestment { get; set; }

        public string InvestmentCompany { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public bool IsFoundedByMe { get; set; }
    }
}
