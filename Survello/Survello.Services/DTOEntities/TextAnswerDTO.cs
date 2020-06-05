using System;

namespace Survello.Services.DTOEntities
{
    public class TextAnswerDTO
    {
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid TextQuestionId { get; set; }
    }
}
