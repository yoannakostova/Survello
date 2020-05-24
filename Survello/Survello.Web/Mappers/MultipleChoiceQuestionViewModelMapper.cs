using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class MultipleChoiceQuestionViewModelMapper
    {
        public static MultipleChoiceQuestionDTO MapFrom(this CreateMultipleChoiceQuestionViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceQuestionDTO
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                IsRequired = viewModel.IsRequired,
                IsMultipleAnswer = viewModel.IsMultipleAnswer,
                Options = viewModel.Options.MapFrom(),
                QuestionNumber = viewModel.QuestionNumber
            };
        }

        public static CreateMultipleChoiceQuestionViewModel MapFrom(this MultipleChoiceQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new CreateMultipleChoiceQuestionViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                IsRequired = dto.IsRequired,
                IsMultipleAnswer = dto.IsMultipleAnswer,
                Options = dto.Options.MapFrom(),
                QuestionNumber = dto.QuestionNumber
            };
        }

        public static ICollection<CreateMultipleChoiceQuestionViewModel> MapFrom(this ICollection<MultipleChoiceQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceQuestionDTO> MapFrom(this ICollection<CreateMultipleChoiceQuestionViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }
    }
}
