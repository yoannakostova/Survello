using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Survello.Models.Entites
{
    public class MultipleChoiceOption
    {
        [Key]
        public Guid Id { get; set; }
        public string Option { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
        public ICollection<MultipleChoiceAnswer> Answers { get; set; } = new List<MultipleChoiceAnswer>();
    }
}
