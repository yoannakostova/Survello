using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class DocumentAnswerConfig : IEntityTypeConfiguration<DocumentAnswer>
    {
        public void Configure(EntityTypeBuilder<DocumentAnswer> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.FileName)
                .IsRequired();

            builder
                .HasOne(a => a.DocumentQuestion)
                .WithMany(dq => dq.Answers)
                .HasForeignKey(a => a.DocumentQuestionId);
        }
    }
}
