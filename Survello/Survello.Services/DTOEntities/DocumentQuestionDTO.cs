using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Survello.Services.DTOEntities
{
   public class DocumentQuestionDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int FileNumberLimit { get; set; }
        public int FileSize { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionNumber { get; set; }
        public ICollection<IFormFile> Files { get; set; }
        public string FilePath { get; set; }
        public ICollection<string> Answers { get; set; } = new List<string>();
    }
}
