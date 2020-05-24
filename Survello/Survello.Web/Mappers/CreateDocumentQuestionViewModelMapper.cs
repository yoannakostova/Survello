using Survello.Models.Entites;
using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class CreateDocumentQuestionViewModelMapper
    {
        public static CreateDocumentQuestionDTO MapFrom(this CreateDocumentQuestionViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }
            var fileSize = int.Parse(viewModel.FileSize.Substring(0,viewModel.FileSize.Length - 2));

            return new CreateDocumentQuestionDTO
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                FileNumberLimit = viewModel.FileNumberLimit,
                FileSize = fileSize,
                IsRequired = viewModel.IsRequired,
                QuestionNumber = viewModel.QuestionNumber
            };
        }
        public static ICollection<CreateDocumentQuestionDTO> MapFrom(this ICollection<CreateDocumentQuestionViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }
        public static CreateDocumentQuestionViewModel MapFrom(this CreateDocumentQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }


            return new CreateDocumentQuestionViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                FileNumberLimit = dto.FileNumberLimit,
                FileSize = dto.FileSize.ToString(),
                IsRequired = dto.IsRequired,
                QuestionNumber = dto.QuestionNumber
            };
        }
        public static ICollection<CreateDocumentQuestionViewModel> MapFrom(this ICollection<CreateDocumentQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
