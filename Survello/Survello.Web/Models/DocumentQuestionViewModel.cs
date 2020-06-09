using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Web.Models
{
    public class DocumentQuestionViewModel 
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string Description { get; set; }
        public int FileNumberLimit { get; set; }
        public string FileSize { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionNumber { get; set; }
        public string FilePath { get; set; }
        public ICollection<IFormFile> Files { get; set; } 
        public ICollection<string> AnswersFileNames { get; set; } = new List<string>();
    }
}
