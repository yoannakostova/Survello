using System;
using System.Collections.Generic;

namespace Survello.Services.DTOEntities
{
    public class FormDTO
    {
        public Guid Id { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfFilledForms { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Guid> CorelationTokens { get; set; }
        public ICollection<MultipleChoiceQuestionDTO> MultipleChoiceQuestions { get; set; }
        public ICollection<TextQuestionDTO> TextQuestions { get; set; }
        public ICollection<DocumentQuestionDTO> DocumentQuestions { get; set; }
    }
}
