using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceOptionDTO
    {
        public Guid Id { get; set; }
        public string Option { get; set; }
        public Guid MultipleChouceQuestionId { get; set; }
        public ICollection<MultipleChoiceOptionDTO> MultipleChoiceOptions { get; set; }
    }
}
