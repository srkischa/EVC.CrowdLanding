using EVC.CrowdLanding.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace EVC.CrowdLanding.Data
{
    public class CrowdFundingsDbContext: DbContext
    {
        public CrowdFundingsDbContext(
            DbContextOptions<CrowdFundingsDbContext> options) : base(options)
        {
        }

        public DbSet<Funding> Fundings { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funding>(fundingModelBuilder =>
            {
                fundingModelBuilder
                    .HasMany(funding => funding.UsersFundings)
                    .WithOne(uf => uf.Funding)
                    .HasForeignKey(uf => uf.FundingId)
                    .IsRequired();
            });

            modelBuilder.Entity<User>(userModelBuilder =>
            {
                userModelBuilder
                    .HasMany(user => user.UsersFundings)
                    .WithOne(uf => uf.User)
                    .HasForeignKey(uf => uf.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<UsersFundings>(userFundingsModelBuilder =>
            {
                userFundingsModelBuilder.HasKey(uf => new { uf.FundingId, uf.UserId });
            });
        }
    }
}
