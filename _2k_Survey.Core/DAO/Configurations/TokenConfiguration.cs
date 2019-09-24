using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    class TokenConfiguration : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.ToTable("Token");
            builder.HasMany(x => x.Related_Surveys).WithOne(y => y.Token).HasForeignKey(x => x.TokenId);
        }
    }
}
