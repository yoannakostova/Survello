using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class TextAnswerViewModel
    {
        public Guid Id { get; set; }
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid TextQuestionId { get; set; }
        public string TextQuestionDescription { get; set; }
    }
}
