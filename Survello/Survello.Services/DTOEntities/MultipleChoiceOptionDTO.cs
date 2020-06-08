using System;
using System.Collections.Generic;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceOptionDTO
    {
        public Guid Id { get; set; }
        public string OptionDescription { get; set; }
        public string Answer { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
    }
}
