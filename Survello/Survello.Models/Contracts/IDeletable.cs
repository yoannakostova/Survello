using System;

namespace Survello.Models.Contracts
{
    public interface IDeletable
    {
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
