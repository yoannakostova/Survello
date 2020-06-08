using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;

namespace Survello.Database.Config
{
    public class MultipleChoiceAnswerConfig : IEntityTypeConfiguration<MultipleChoiceAnswer>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceAnswer> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasOne(a => a.MultipleChoiceQuestion)
                .WithMany(o => o.Answers)
                .HasForeignKey(a => a.MultipleChoiceQuestionId);
        }
    }
}
