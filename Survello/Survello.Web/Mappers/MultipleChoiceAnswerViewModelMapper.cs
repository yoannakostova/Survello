using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class MultipleChoiceAnswerViewModelMapper
    {
        public static MultipleChoiceAnswerDTO MapFrom(this MultipleChoiceAnswerViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceAnswerDTO
            {
                Id = viewModel.Id,
                MultipleChoiceQuestionId = viewModel.MultipleChoiceQuestionId
            };
        }

        public static MultipleChoiceAnswerViewModel MapFrom(this MultipleChoiceAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceAnswerViewModel
            {
                Id = dto.Id,
                MultipleChoiceQuestionId = dto.MultipleChoiceQuestionId
            };
        }

        public static ICollection<MultipleChoiceAnswerViewModel> MapFrom(this ICollection<MultipleChoiceAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceAnswerDTO> MapFrom(this ICollection<MultipleChoiceAnswerViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }
    }
}
