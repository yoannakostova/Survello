using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
    }
}
