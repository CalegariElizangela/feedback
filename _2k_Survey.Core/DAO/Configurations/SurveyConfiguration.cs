using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Survey");
            builder.HasMany(x => x.Related_Surveys).WithOne(y => y.Survey).HasForeignKey(x => x.SurveyId);

            builder.HasMany(x => x.SurveyItems).WithOne(y => y.Survey).HasForeignKey(x => x.SurveyId);
        }
    }
}
