using System;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceAnswerDTO
    {
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid MultipleChoiceOptionId { get; set; }
    }
}
