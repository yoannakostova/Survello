using Survello.Database;
using Survello.Services.DTOEntities;
using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survello.Services.Services
{
    public class TextQuestionServices : ITextQuestionServices
    {
        private readonly SurvelloContext dbcontext;

        public TextQuestionServices(SurvelloContext context)
        {
            this.dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }
        public Task<TextQuestionDTO> CreateTextQuestionAsync(TextQuestionDTO textQuestion)
        {
            

                return null;
        }

        public Task DeleteTextQuestion(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TextQuestionDTO> UpdateTextQuestionAsync(TextQuestionDTO textQuestion)
        {
            throw new NotImplementedException();
        }
    }
}
