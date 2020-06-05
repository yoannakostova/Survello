using System;
using System.Collections.Generic;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceOptionDTO
    {
        public Guid Id { get; set; }
        public string Option { get; set; }
        public string Answer { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
        public ICollection<MultipleChoiceAnswerDTO> Answers { get; set; } = new List<MultipleChoiceAnswerDTO>();
    }
}
