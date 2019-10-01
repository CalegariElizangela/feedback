using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    public class ResponseItemConfiguration : IEntityTypeConfiguration<ResponseItem>
    {
        public void Configure(EntityTypeBuilder<ResponseItem> builder)
        {
            builder.ToTable("ResponseItem");
            builder.HasKey(x => x.ResponseItemId);

            builder.HasOne(x => x.Response).WithMany(y => y.ResponseItems).HasForeignKey(x => x.ResponseId);
        }
    }
}
