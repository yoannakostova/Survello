using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Database.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class AnsweredOptionsQuestionConfig : IEntityTypeConfiguration<AnsweredOptionsQuestion>
    {
        public void Configure(EntityTypeBuilder<AnsweredOptionsQuestion> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasOne(a => a.OptionsQuestion)
                .WithMany(o => o.Answers)
                .HasForeignKey(a => a.OptionQuestionId);
        }
    }
}
