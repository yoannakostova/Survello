using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class DocumentQuestionConfig : IEntityTypeConfiguration<DocumentQuestion>
    {
        public void Configure(EntityTypeBuilder<DocumentQuestion> builder)
        {
            builder
                 .HasQueryFilter(p => !p.IsDeleted);

            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Description)
                .IsRequired();

            builder
                .HasOne(d => d.Form)
                .WithMany(f => f.DocumentQuestions)
                .HasForeignKey(d => d.FormId);
        }
    }
}
