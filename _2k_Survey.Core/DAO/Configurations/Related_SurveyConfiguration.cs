using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    class Related_SurveyConfiguration : IEntityTypeConfiguration<Related_Survey>
    {
        public void Configure(EntityTypeBuilder<Related_Survey> builder)
        {
            builder.ToTable("Related_Survey");
            builder.HasKey(x => x.RelatedSurveyId);
            builder.HasOne(x => x.Token).WithMany(y => y.Related_Surveys).HasForeignKey(x => x.TokenId);
            builder.HasOne(x => x.Survey).WithMany(y => y.Related_Surveys).HasForeignKey(x => x.SurveyId);
            builder.HasOne(x => x.Response).WithMany(y => y.Related_Surveys).HasForeignKey(x => x.ResponseId);
        }
    }
}
