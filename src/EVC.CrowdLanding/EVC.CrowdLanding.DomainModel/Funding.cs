using System;
using System.Collections.Generic;

namespace EVC.CrowdLanding.DomainModel
{
    public class Funding : Entity
    {
        public bool IsInvestmentRequired { get; set; }

        public string Description { get; set; }

        public string TypeOfInvestment { get; set; }

        public string InvestmentCompany { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<UsersFundings> UsersFundings { get; set; }
    }
}
