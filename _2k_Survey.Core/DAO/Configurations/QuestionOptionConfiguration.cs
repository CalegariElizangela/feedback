using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            builder.ToTable("QuestionOption");
            builder.HasKey(x => x.QuestionOptionId);

            builder.HasMany(x => x.SurveyItems).WithOne(y => y.QuestionOption).HasForeignKey(x => x.QuestionOptionId);
        }
    }
}
