using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Web.Models
{
    public class MultipleChoiceOptionViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Option { get; set; }
        public string Answer { get; set; }
        public ICollection<MultipleChoiceAnswerViewModel> Answers { get; set; } = new List<MultipleChoiceAnswerViewModel>();
    }
}
