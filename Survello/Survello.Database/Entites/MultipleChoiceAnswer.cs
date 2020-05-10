using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Database.Entites
{
    public class MultipleChoiceAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }

        //public ICollection<MultipleChoiceOption> MultipleChoiceOptions { get; set; }
    }
}
