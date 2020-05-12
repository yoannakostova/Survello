using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasQueryFilter(p => !p.IsDeleted);

            builder
                .HasKey(r => r.Id);
        }
    }
}
