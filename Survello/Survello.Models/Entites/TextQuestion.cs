using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Models.Entites
{
    public class TextQuestion
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsLongAnswer { get; set; }
        public bool IsRequired { get; set; }
        public bool IsDeleted { get; set; }
        public Guid FormId { get; set; }
        public Form Form { get; set; }
        //TODO: Where to initialize the collection
        public ICollection<TextAnswer> Answers { get; set; }
    }
}
