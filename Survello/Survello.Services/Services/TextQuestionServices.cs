using Microsoft.EntityFrameworkCore;
using Survello.Database;
using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Services.DTOMappers;
using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services
{
    public class TextQuestionServices : ITextQuestionServices
    {
        private readonly SurvelloContext dbcontext;

        public TextQuestionServices(SurvelloContext dbcontext)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<ICollection<CreateTextQuestionDTO>> GetAllTextQuestionInForm(Guid id)
        {
            var textQuestions = await this.dbcontext.TextQuestions
                .Where(t => t.FormId == id)
                .ToListAsync();

            if (textQuestions == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return textQuestions.MapFrom();
        }
    }
}
