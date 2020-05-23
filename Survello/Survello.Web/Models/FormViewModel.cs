using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class FormViewModel
    {
        public Guid Id { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfFilledForms { get; set; }
        public Guid UserId { get; set; }
        public Dictionary<int, IQuestion> QuestionNumbers { get; set; } = new Dictionary<int, IQuestion>();
        public ICollection<MultipleChoiceQuestionViewModel> MultipleChoiceQuestions { get; set; } = new List<MultipleChoiceQuestionViewModel>();
        public ICollection<TextQuestionViewModel> TextQuestions { get; set; } = new List<TextQuestionViewModel>();
        public ICollection<DocumentQuestionViewModel> DocumentQuestions { get; set; } = new List<DocumentQuestionViewModel>();
    }
}
