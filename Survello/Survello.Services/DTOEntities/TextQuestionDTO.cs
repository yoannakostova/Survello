using System;
using System.Collections.Generic;

namespace Survello.Services.DTOEntities
{
    public class TextQuestionDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsLongAnswer { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionNumber { get; set; }
        public string Answer { get; set; }
        public Guid FormId { get; set; }
        public ICollection<TextAnswerDTO> Answers { get; set; } = new List<TextAnswerDTO>();

    }
}
