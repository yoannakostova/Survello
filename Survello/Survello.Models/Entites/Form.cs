﻿using Survello.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Survello.Models.Entites
{
    public class Form : Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfFilledForms { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; } = new List<MultipleChoiceQuestion>();
        public ICollection<TextQuestion> TextQuestions { get; set; } = new List<TextQuestion>();
        public ICollection<DocumentQuestion> DocumentQuestions { get; set; } = new List<DocumentQuestion>();
    }
}
