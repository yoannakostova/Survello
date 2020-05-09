using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class AnsweredTextQuestionConfig : IEntityTypeConfiguration<AnsweredTextQuestion>
    {
        public void Configure(EntityTypeBuilder<AnsweredTextQuestion> builder)
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
