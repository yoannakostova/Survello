using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class TextQuestionConfig : IEntityTypeConfiguration<TextQuestion>
    {
        public void Configure(EntityTypeBuilder<TextQuestion> builder)
        {
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
