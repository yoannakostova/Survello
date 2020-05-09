using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class OptionsQuestionOptionConfig : IEntityTypeConfiguration<OptionsQuestionOption>
    {
        public void Configure(EntityTypeBuilder<OptionsQuestionOption> builder)
        {
            builder
                .HasKey(o => o.Id);

            builder
                .Property(o => o.Option)
                .IsRequired();

            builder
                .HasOne(o => o.OptionQuestion)
                .WithMany(o => o.Options)
                .HasForeignKey(o => o.OptionQuestionID);

        }
    }
}
