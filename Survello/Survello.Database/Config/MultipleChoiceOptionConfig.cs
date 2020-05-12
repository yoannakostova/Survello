using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

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
                .HasForeignKey(o => o.MultipleChouceQuestionId);
        }
    }
}
