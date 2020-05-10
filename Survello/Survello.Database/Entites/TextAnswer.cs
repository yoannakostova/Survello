using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Database.Entites
{
    public class TextAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public string Answer { get; set; }
        public Guid TextQuestionId { get; set; }
        public TextQuestion TextQuestion { get; set; }
    }
}
