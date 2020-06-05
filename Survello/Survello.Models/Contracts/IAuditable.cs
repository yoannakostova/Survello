using System;

namespace Survello.Models.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; } 
        DateTime? LastModifiedOn { get; set; }
    }
}
