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
        public string OptionDescription { get; set; }
        public string Answer { get; set; }
    }
}
