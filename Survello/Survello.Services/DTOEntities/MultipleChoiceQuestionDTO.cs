using System;
using System.Collections.Generic;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceQuestionDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public int QuestionNumber { get; set; }
        public ICollection<MultipleChoiceOptionDTO> Options { get; set; }
        public ICollection<string> Answers { get; set; }
    }
}
