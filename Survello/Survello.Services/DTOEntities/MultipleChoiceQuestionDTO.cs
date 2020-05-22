using System;
using System.Collections.Generic;
using System.Text;

namespace Survello.Services.DTOEntities
{
    public class MultipleChoiceQuestionDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public bool IsMultipleAnswer { get; set; }
        public Guid FormId { get; set; }
        public string FormName { get; set; }
        public ICollection<MultipleChoiceOptionDTO> Options { get; set; }
    }
}
