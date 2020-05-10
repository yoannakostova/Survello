using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Database.Entites
{
    public class MultipleChoiceOption
    {
        [Key]
        public Guid Id { get; set; }
        public string Option { get; set; }
        public Guid MultipleChouceQuestionId { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
