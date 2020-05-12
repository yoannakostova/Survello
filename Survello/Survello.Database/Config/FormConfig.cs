using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class FormConfig : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder
                .HasQueryFilter(p => !p.IsDeleted);

            builder
                .HasKey(f => f.Id);

            builder
                .Property(f => f.Title)
                .IsRequired();

            builder
                .HasOne(f => f.User)
                .WithMany(u => u.Forms)
                .HasForeignKey(f => f.UserId);
        }
    }
}
