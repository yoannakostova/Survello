﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Models
{
    public class ListFormsViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public int NumberOfFilledForms { get; set; }
        public string Recipients { get; set; }
    }
}
