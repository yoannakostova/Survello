using Microsoft.AspNetCore.Identity;
using Survello.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class MultipleChoiceQuestionViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public Guid FormId { get; set; }
        public string FormName { get; set; }
        public ICollection<string> OptionsDescriptions { get; set; }
        public ICollection<MultipleChoiceOptionViewModel> Options { get; set; }
    }
}
