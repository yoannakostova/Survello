﻿using Survello.Web.Models;
using Survello.Web.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class CreateFormViewModel
    {
        public Guid Id { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Title { get; set; }
        [StringLength(300, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public SortedDictionary<int, IQuestion> QuestionNumbers { get; set; } = new SortedDictionary<int, IQuestion>();
        public ICollection<CreateMultipleChoiceQuestionViewModel> MultipleChoiceQuestions { get; set; } = new List<CreateMultipleChoiceQuestionViewModel>();
        public ICollection<CreateTextQuestionViewModel> TextQuestions { get; set; } = new List<CreateTextQuestionViewModel>();
        public ICollection<CreateDocumentQuestionViewModel> DocumentQuestions { get; set; } = new List<CreateDocumentQuestionViewModel>();
    }
}
