using System.ComponentModel.DataAnnotations;

namespace EVC.CrowdLanding.Api.Model
{
    public class CreateUserFundingRequest
    {
        [Required]
        public int FundingId { get; set; }

        [Range(100, 10000)]
        [Required]
        public decimal FundingAmount { get; set; }
    }
}
