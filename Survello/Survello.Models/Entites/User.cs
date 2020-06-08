using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Survello.Models.Entites
{
    public class User : IdentityUser<Guid>
    {
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Form> Forms { get; set; } = new List<Form>();
    }
}
