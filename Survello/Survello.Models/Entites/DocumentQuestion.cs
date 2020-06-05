using Survello.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Models.Entites
{
    public class DocumentQuestion : IDeletable
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int FileNumberLimit { get; set; }
        public int FileSize { get; set; }
        public Guid FormId { get; set; }
        public Form Form { get; set; }
        public bool IsRequired { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get;  set; }
        public int QuestionNumber { get; set; }
        public ICollection<DocumentAnswer> Answers { get; set; } = new List<DocumentAnswer>();
    }
}
