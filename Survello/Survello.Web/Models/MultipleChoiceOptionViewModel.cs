using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class MultipleChoiceOptionViewModel
    {
        public Guid Id { get; set; }
        public string Option { get; set; }
        public Guid MultipleChouceQuestionId { get; set; }
        public string MultipleChoiceQuestionDescription { get; set; }
    }
}
