using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    public class ResponseConfiguration : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.ToTable("Response");
            builder.HasKey(x => x.ResponseId);
            builder.Property(x => x.CreateDate);

            builder.HasMany(x => x.ResponseItems).WithOne(y => y.Response).HasForeignKey(x => x.ResponseId);
        }
    }
}
