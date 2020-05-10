using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class TextQuestionDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsLongAnswer { get; set; }
        public bool IsRequired { get; set; }
        public Guid FormId { get; set; }
        public string FormTitle { get; set; }
        public ICollection<TextAnswerDTO> Answers { get; set; }
    }
}
