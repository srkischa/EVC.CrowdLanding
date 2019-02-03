using System;
using System.ComponentModel.DataAnnotations;

namespace EVC.CrowdLanding.Service.Model
{
    public class NewFundingDto
    {
        [Required]
        public int FundingId { get; set; }

        [Range(100, 10000)]
        public decimal FundingAmount { get; set; }
    }
}
