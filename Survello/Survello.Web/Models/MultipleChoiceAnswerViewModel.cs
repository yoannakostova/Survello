using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class MultipleChoiceAnswerViewModel
    {
        public Guid Id { get; set; }
        public Guid CorelationToken { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
    }
}
