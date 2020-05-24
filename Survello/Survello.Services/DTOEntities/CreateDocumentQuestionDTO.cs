using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
   public class CreateDocumentQuestionDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int FileNumberLimit { get; set; }
        public int FileSize { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionNumber { get; set; }
        public Guid FormId { get; set; }
    }
}
