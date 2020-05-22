using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class DocumentAnswerViewModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Guid DocumentQuestionId { get; set; }
        public Guid CorelationToken { get; set; }
    }
}
