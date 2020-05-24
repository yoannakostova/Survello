using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class CreateTextQuestionViewModelMapper
    {
        public static CreateTextQuestionViewModel MapFrom(this CreateTextQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new CreateTextQuestionViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                IsLongAnswer = dto.IsLongAnswer,
                IsRequired = dto.IsRequired,
                QuestionNumber = dto.QuestionNumber
            };
        }

        public static CreateTextQuestionDTO MapFrom(this CreateTextQuestionViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new CreateTextQuestionDTO
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                IsLongAnswer = viewModel.IsLongAnswer,
                IsRequired = viewModel.IsRequired,
                QuestionNumber = viewModel.QuestionNumber
            };
        }

        public static ICollection<CreateTextQuestionDTO> MapFrom(this ICollection<CreateTextQuestionViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }

        public static ICollection<CreateTextQuestionViewModel> MapFrom(this ICollection<CreateTextQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
