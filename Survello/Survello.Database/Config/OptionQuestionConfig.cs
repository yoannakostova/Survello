using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class OptionQuestionConfig : IEntityTypeConfiguration<OptionsQuestion>
    {
        public void Configure(EntityTypeBuilder<OptionsQuestion> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Description)
                .IsRequired();

            builder
                .HasOne(o => o.Form)
                .WithMany(f => f.OptionsQuestions)
                .HasForeignKey(o => o.FormId);
        }
    }
}
