using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;

namespace Survello.Database.Config
{
    public class TextAnswerConfig : IEntityTypeConfiguration<TextAnswer>
    {
        public void Configure(EntityTypeBuilder<TextAnswer> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Answer)
                .IsRequired();

            builder
                .HasOne(a => a.TextQuestion)
                .WithMany(t => t.Answers)
                .HasForeignKey(a => a.TextQuestionId);
        }
    }
}
