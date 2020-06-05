using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;

namespace Survello.Database.Config
{
    public class MultipleChoiceQuestionConfig : IEntityTypeConfiguration<MultipleChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
        {
            builder
                .HasQueryFilter(p => !p.IsDeleted);

            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Description)
                .IsRequired();

            builder
                .HasOne(o => o.Form)
                .WithMany(f => f.MultipleChoiceQuestions)
                .HasForeignKey(o => o.FormId);
        }
    }
}
