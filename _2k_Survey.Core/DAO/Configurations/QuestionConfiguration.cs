using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2k_Survey.Core.DAO.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Question");
            builder.HasKey(x => x.QuestionId);

            builder.HasMany(x => x.SurveyItems).WithOne(y => y.Question).HasForeignKey(x => x.QuestionId);
        }
    }
}
