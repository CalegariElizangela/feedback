using _2k_Survey.Core.DAO.Configurations;
using _2k_Survey.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _2k_Survey.Core.DAO
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Related_Survey> Related_Surveys { get; set; }
        public DbSet<Response> Response { get; set; }
        public DbSet<ResponseItem> ResponseItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Related_SurveyConfiguration());
            modelBuilder.ApplyConfiguration(new TokenConfiguration());
            modelBuilder.ApplyConfiguration(new SurveyConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionOptionConfiguration());
            modelBuilder.ApplyConfiguration(new SurveyItemConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseConfiguration());
            modelBuilder.ApplyConfiguration(new ResponseItemConfiguration());
        }
    }
}
