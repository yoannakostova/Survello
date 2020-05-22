using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class MultipleChoiceQuestionViewModel : IQuestion
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public Guid FormId { get; set; }
        public string FormName { get; set; }
        public int QuestionNumber { get; set; }
        public ICollection<string> OptionsDescriptions { get; set; }
        public ICollection<MultipleChoiceOptionViewModel> Options { get; set; } = new List<MultipleChoiceOptionViewModel>();
    }
}
