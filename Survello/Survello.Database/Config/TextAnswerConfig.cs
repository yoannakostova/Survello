using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

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
