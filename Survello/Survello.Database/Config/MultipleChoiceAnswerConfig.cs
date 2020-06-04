﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class MultipleChoiceAnswerConfig : IEntityTypeConfiguration<MultipleChoiceAnswer>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceAnswer> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasOne(a => a.MultipleChoiceOption)
                .WithMany(o => o.Answers)
                .HasForeignKey(a => a.MultipleChoiceOptionId);
        }
    }
}
