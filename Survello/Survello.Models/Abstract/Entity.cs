using Survello.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Survello.Models.Abstract
{
    public abstract class Entity : IAuditable, IDeletable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date)]
        public DateTime? LastModifiedOn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
