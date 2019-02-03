using EVC.CrowdLanding.Data;
using EVC.CrowdLanding.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVC.CrowdLanding.Api.Migrations.Seed
{
    public class CrowdFundingDbSeed: IContextSeed<CrowdFundingsDbContext>
    {
        public void Seed(CrowdFundingsDbContext context)
        {
            if (!context.Fundings.Any())
            {
                context.Fundings.AddRange(GetRandomFindings());
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(GetUsers());
                context.SaveChanges();
            }
        }

        private IEnumerable<Funding> GetRandomFindings()
        {
            var random = new Random();
            
            for (int i = 0; i < 50; i++)
            {
                var randomNumber = random.Next(0, 100);
                yield return new Funding
                {
                    IsInvestmentRequired = randomNumber > 20,
                    Description = $"Funding of property No{i}",
                    TypeOfInvestment = "PropertyInvestment",
                    InvestmentCompany = $"Company{randomNumber % 5 + 1}",
                    StartTime = DateTime.UtcNow.AddDays(-2 * randomNumber),
                    EndTime = DateTime.UtcNow.AddDays(3 * randomNumber)
                };
            }
        }

        private IEnumerable<User> GetUsers()
        {
            yield return new User
            {
                FirstName = "Srdjan",
                LastName = "Milovanov",
                Email = "s.milovanov@gmail.com"
            };

            yield return new User
            {
                FirstName = "Paul",
                LastName = "Backhouse",
                Email = "p.blackhouse@gmail.com"
            };
        }
    }
}
