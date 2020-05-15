using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Models.Contracts
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; } 
        DateTime? LastModifiedOn { get; set; }
    }
}
