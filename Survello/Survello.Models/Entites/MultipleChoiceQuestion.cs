using Survello.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Models.Entites
{
    public class MultipleChoiceQuestion : IDeletable
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Guid FormId { get; set; }
        public Form Form { get; set; }
        public ICollection<MultipleChoiceOption> Options { get; set; } = new List<MultipleChoiceOption>();
    }
}
