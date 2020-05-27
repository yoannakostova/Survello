using Survello.Web.Models;
using Survello.Web.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class MultipleChoiceQuestionViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public int QuestionNumber { get; set; }
        public List<string> OptionsDescriptions { get; set; } = new List<string>();
        public List<MultipleChoiceOptionViewModel> Options { get; set; } = new List<MultipleChoiceOptionViewModel>();
    }
}
