using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Database.Entites
{
    public class Form
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfFilledForms { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public ICollection<TextQuestion> TextQuestions { get; set; }
        //public ICollection<DocumentQuestion> DocumentQuestions { get; set; }
    }
}
