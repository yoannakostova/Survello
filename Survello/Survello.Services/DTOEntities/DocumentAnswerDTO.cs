using System;

namespace Survello.Services.DTOEntities
{
    public class DocumentAnswerDTO
    {
        public string FileName { get; set; }
        public Guid DocumentQuestionId { get; set; }
        public Guid CorelationToken { get; set; }
    }
}
