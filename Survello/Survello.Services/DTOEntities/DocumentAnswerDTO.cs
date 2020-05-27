using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class DocumentAnswerDTO
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public bool IsDeleted { get; set; }
        public Guid DocumentQuestionId { get; set; }
        public Guid CorelationToken { get; set; }
    }
}
