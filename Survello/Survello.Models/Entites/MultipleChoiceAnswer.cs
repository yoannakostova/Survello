using System;
using System.ComponentModel.DataAnnotations;

namespace Survello.Models.Entites
{
    public class MultipleChoiceAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CorelationToken { get; set; }
        public string Answer { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
