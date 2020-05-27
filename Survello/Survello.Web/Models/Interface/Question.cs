using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//TODO: Change this when optimizing - don`t yet know how to optimize the rendiring...
namespace Survello.Web.Models.Interface
{
    public class Question
    {
        public int Position { get; set; }
        public Guid Id { get; set; }
        public string QuestionType { get; set; }
    }
}

