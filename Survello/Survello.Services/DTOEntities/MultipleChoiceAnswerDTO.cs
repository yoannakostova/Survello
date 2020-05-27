using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public bool IsDeleted { get; set; }
        public Guid MultipleChoiceOptionId { get; set; }

    }
}
