using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Database.Entites
{
    public class User : IdentityUser<Guid>
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOn { get; set; }
        //TODO: Where to initialize this collection, maybe the optimal place is in the services?
        public ICollection<Form> Forms { get; set; } 
    }
}
