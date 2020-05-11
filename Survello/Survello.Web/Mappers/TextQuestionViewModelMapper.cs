using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class TextQuestionViewModelMapper
    {
        public static TextQuestionViewModel MapFrom(this TextQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new TextQuestionViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                IsLongAnswer = dto.IsLongAnswer,
                IsRequired = dto.IsRequired,
                Answers = dto.Answers.MapFrom(),
                FormId = dto.FormId,
                FormTitle = dto.FormTitle
            };
        }

        public static TextQuestionDTO MapFrom(this TextQuestionViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new TextQuestionDTO
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                IsLongAnswer = viewModel.IsLongAnswer,
                IsRequired = viewModel.IsRequired,
                Answers = viewModel.Answers.MapFrom(),
                FormId = viewModel.FormId,
                FormTitle = viewModel.FormTitle
            };
        }

        public static ICollection<TextQuestionDTO> MapFrom(this ICollection<TextQuestionViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }

        public static ICollection<TextQuestionViewModel> MapFrom(this ICollection<TextQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
