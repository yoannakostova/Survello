using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class TextAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid TextQuestionId { get; set; }
        public string TextQuestionDescription { get; set; }
    }
}
