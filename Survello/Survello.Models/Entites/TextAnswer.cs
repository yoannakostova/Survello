using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Models.Entites
{
    public class TextAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid TextQuestionId { get; set; }
        public TextQuestion TextQuestion { get; set; }
    }
}
