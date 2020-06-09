using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Models.Entites
{
    public class Form
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfFilledForms { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; } = new List<MultipleChoiceQuestion>();
        public ICollection<TextQuestion> TextQuestions { get; set; } = new List<TextQuestion>();
        public ICollection<DocumentQuestion> DocumentQuestions { get; set; } = new List<DocumentQuestion>();
    }
}
