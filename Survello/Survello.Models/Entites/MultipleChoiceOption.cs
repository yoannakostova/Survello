﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Models.Entites
{
    public class MultipleChoiceOption
    {
        [Key]
        public Guid Id { get; set; }
        public string Option { get; set; }
        public Guid MultipleChoiceQuestionId { get; set; }
        public MultipleChoiceQuestion MultipleChoiceQuestion { get; set; }
    }
}
