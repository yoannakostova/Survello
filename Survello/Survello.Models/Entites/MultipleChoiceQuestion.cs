﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Models.Entites
{
    public class MultipleChoiceQuestion
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public bool IsDeleted { get; set; }
        public Guid FormId { get; set; }
        public Form Form { get; set; }
        public int QuestionNumber { get; set; }
        public ICollection<MultipleChoiceOption> Options { get; set; } = new List<MultipleChoiceOption>();
        public ICollection<MultipleChoiceAnswer> Answers { get; set; } = new List<MultipleChoiceAnswer>();
    }
}
