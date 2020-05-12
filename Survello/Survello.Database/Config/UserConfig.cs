using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasQueryFilter(p => !p.IsDeleted);

            builder
                .HasKey(u => u.Id);
        }
    }
}
//TODO: NOTE, if you want to ignore the global queries, this is the code that needs to be added:
//Example:

//blogs = db.Blogs
//.Include(b => b.Posts)
//.IgnoreQueryFilters()
//.ToList();
