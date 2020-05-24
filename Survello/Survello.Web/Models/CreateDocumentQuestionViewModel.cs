using Survello.Models.Entites;
using Survello.Web.Models;
using Survello.Web.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class CreateDocumentQuestionViewModel :IQuestion
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int FileNumberLimit { get; set; }
        public string FileSize { get; set; }
        public bool IsRequired { get; set; }
        public int QuestionNumber { get; set; }
    }
}
