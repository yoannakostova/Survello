using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class MultipleChoiceQuestionViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public Guid FormId { get; set; }
        public string FormName { get; set; }
        public ICollection<MultipleChoiceAnswerViewModel> Answers { get; set; }
        public ICollection<MultipleChoiceOptionViewModel> Options { get; set; }
    }
}
