using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Models.Entites
{
    public class MultipleChoiceAnswer
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CorelationToken { get; set; }
        public bool IsDeleted { get; set; }
        public Guid MultipleChoiceOptionId { get; set; }
        public MultipleChoiceOption MultipleChoiceOption { get; set; }
    }
}
