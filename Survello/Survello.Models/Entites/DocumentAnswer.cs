using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Models.Entites
{
   public class DocumentAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Guid DocumentQuestionId { get; set; }
        public DocumentQuestion DocumentQuestion { get; set; }
        public Guid CorelationToken { get; set; }
    }
}
