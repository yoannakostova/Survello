using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Database.Entites
{
    public class AnsweredOptionsQuestion
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OptionQuestionId { get; set; }
        public OptionsQuestion OptionsQuestion { get; set; }
        public ICollection<OptionsQuestionOption> OptionsQuestionOptions { get; set; }
    }
}
