using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Survello.Database.Config;
using Survello.Models.Entites;
using Survello.Seeder;
using System;

namespace Survello.Database
{
    public class SurvelloContext : IdentityDbContext<User, Role, Guid>
    {
        public SurvelloContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TextQuestion> TextQuestions { get; set; }
        public DbSet<TextAnswer> TextAnswers { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<MultipleChoiceOption> MultipleChoiceOptions { get; set; }
        public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
        public DbSet<DocumentQuestion> DocumentQuestions { get; set; }
        public DbSet<DocumentAnswer> DocumentAnswers { get; set; }
        public DbSet<Form> Forms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new FormConfig());
            modelBuilder.ApplyConfiguration(new TextQuestionConfig());
            modelBuilder.ApplyConfiguration(new MultipleChoiceQuestionConfig());
            modelBuilder.ApplyConfiguration(new TextAnswerConfig());
            modelBuilder.ApplyConfiguration(new MultipleChoiceOptionConfig());
            modelBuilder.ApplyConfiguration(new MultipleChoiceAnswerConfig());
            modelBuilder.ApplyConfiguration(new DocumentQuestionConfig());
            modelBuilder.ApplyConfiguration(new DocumentAnswerConfig());

            modelBuilder.Seeder();
            ///modelBuilder.ReadRaw();

            base.OnModelCreating(modelBuilder);
        }
    }
}
