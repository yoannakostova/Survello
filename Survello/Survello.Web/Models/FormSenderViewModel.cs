using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class FormSenderViewModel
    {
        [Required(ErrorMessage = "Required field!")]
        public string To { get; set; }
        [Required(ErrorMessage = "Required field!")]
        public string Subject { get; set; }
        public Guid FormId { get; set; }
    }
}
