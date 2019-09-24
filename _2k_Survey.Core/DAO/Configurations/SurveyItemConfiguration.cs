using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    public class SurveyItemConfiguration : IEntityTypeConfiguration<SurveyItem>
    {
        public void Configure(EntityTypeBuilder<SurveyItem> builder)
        {
            builder.ToTable("SurveyItem");
            builder.HasKey(x => x.SurveyItemId);

            builder.HasOne(x => x.Survey).WithMany(w => w.SurveyItems).HasForeignKey(x => x.SurveyId);
            builder.HasOne(x => x.Group).WithMany(w => w.SurveyItems).HasForeignKey(x => x.GroupId);
            builder.HasOne(x => x.Question).WithMany(w => w.SurveyItems).HasForeignKey(x => x.QuestionId);
            builder.HasOne(x => x.QuestionOption).WithMany(w => w.SurveyItems).HasForeignKey(x => x.QuestionOptionId);
        }
    }
}
