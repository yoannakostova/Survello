using Microsoft.AspNetCore.Http;
using Survello.Web.Models;
using Survello.Web.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class FormViewModel
    {
        [Required]
        public Guid Id { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Title { get; set; }
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public List<Question> QuestionNumbers { get; set; } = new List<Question>();
        public List<MultipleChoiceQuestionViewModel> MultipleChoiceQuestions { get; set; } = new List<MultipleChoiceQuestionViewModel>();
        public List<TextQuestionViewModel> TextQuestions { get; set; } = new List<TextQuestionViewModel>();
        public List<DocumentQuestionViewModel> DocumentQuestions { get; set; } = new List<DocumentQuestionViewModel>();        
    }
}
