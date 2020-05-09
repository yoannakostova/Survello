using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Survello.Database.Config;
using Survello.Database.Entites;
using System;

namespace Survello.Database
{
    public class SurvelloContext : IdentityDbContext<User, Role, Guid>
    {
        public SurvelloContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TextQuestion> TextQuestions { get; set; }
        public DbSet<AnsweredTextQuestion> AnsweredTextQuestions { get; set; }
        public DbSet<OptionsQuestion> OptionsQuestions { get; set; }
        public DbSet<OptionsQuestionOption> OptionsQuestionOptions { get; set; }
        public DbSet<AnsweredOptionsQuestion> AnsweredOptionsQuestions { get; set; }
        public DbSet<Form> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new FormConfig());
            modelBuilder.ApplyConfiguration(new TextQuestionConfig());
            modelBuilder.ApplyConfiguration(new OptionQuestionConfig());
            modelBuilder.ApplyConfiguration(new AnsweredTextQuestionConfig());
            modelBuilder.ApplyConfiguration(new OptionsQuestionOptionConfig());
            modelBuilder.ApplyConfiguration(new AnsweredOptionsQuestionConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
