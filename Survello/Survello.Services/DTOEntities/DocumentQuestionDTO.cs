using Microsoft.AspNetCore.Http;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Text;

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
        public Guid FormId { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
        public string FilePath { get; set; }
        public ICollection<DocumentAnswerDTO> Answers { get; set; } = new List<DocumentAnswerDTO>();

    }
}
