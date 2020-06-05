using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;

namespace Survello.Database.Config
{
    public class TextQuestionConfig : IEntityTypeConfiguration<TextQuestion>
    {
        public void Configure(EntityTypeBuilder<TextQuestion> builder)
        {
            builder
                .HasQueryFilter(p => !p.IsDeleted);

            builder
                .HasKey(t => t.Id);

            builder
                .Property(t => t.Description)
                .IsRequired();

            builder
                .HasOne(t => t.Form)
                .WithMany(f => f.TextQuestions)
                .HasForeignKey(t => t.FormId);

        }
    }
}
