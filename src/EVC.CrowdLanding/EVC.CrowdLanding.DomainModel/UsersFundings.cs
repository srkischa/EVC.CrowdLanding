using System;

namespace EVC.CrowdLanding.DomainModel
{
    public class UsersFundings
    {
        public int UserId { get; set; }

        public int FundingId { get; set; }

        public DateTime TimeOfFunding { get; set; }

        public decimal Amount { get; set; }

        public Funding Funding { get; set; }

        public User User { get; set; }
    }
}
