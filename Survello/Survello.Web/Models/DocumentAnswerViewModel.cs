using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class DocumentAnswerViewModel
    {
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid DocumentQuestionId { get; set; }
    }
}
