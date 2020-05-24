using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class CreateFormDTO
    {
        public Guid Id { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfFilledForms { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CreateMultipleChoiceQuestionDTO> MultipleChoiceQuestions { get; set; }
        public ICollection<CreateTextQuestionDTO> TextQuestions { get; set; }
        public ICollection<CreateDocumentQuestionDTO> DocumentQuestions { get; set; }
    }
}
