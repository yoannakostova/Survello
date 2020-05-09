using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Survello.Database.Entites
{
    public class OptionsQuestionOption
    {
        [Key]
        public Guid Id { get; set; }
        public string Option { get; set; }
        public Guid OptionQuestionID { get; set; }
        public OptionsQuestion OptionQuestion { get; set; }
    }
}
