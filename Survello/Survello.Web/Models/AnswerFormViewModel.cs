using Survello.Web.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class AnswerFormViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<CreateMultipleChoiceQuestionViewModel> MultipleChoiceQuestions { get; set; } = new List<CreateMultipleChoiceQuestionViewModel>();
        public ICollection<CreateTextQuestionViewModel> TextQuestions { get; set; } = new List<CreateTextQuestionViewModel>();
        public ICollection<CreateDocumentQuestionViewModel> DocumentQuestions { get; set; } = new List<CreateDocumentQuestionViewModel>();
        public SortedDictionary<int, IQuestion> QuestionNumbers { get; set; } = new SortedDictionary<int, IQuestion>();
    }
}
