using System;

namespace Survello.Web.Models
{
    public class TextAnswerViewModel
    {
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid TextQuestionId { get; set; }
    }
}
