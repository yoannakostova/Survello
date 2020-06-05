using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;

namespace Survello.Database.Config
{
    public class MultipleChoiceOptionConfig : IEntityTypeConfiguration<MultipleChoiceOption>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceOption> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Option)
                .IsRequired();

            builder
                .HasOne(o => o.MultipleChoiceQuestion)
                .WithMany(o => o.Options)
                .HasForeignKey(o => o.MultipleChoiceQuestionId);                
        }
    }
}
