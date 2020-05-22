using Survello.Web.Models.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class TextQuestionViewModel :IQuestion
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsLongAnswer { get; set; }
        public bool IsRequired { get; set; }
        public Guid FormId { get; set; }
        public string FormTitle { get; set; }
        public int QuestionNumber { get; set; }
        public ICollection<TextAnswerViewModel> Answers { get; set; } = new List<TextAnswerViewModel>();
    }
}
