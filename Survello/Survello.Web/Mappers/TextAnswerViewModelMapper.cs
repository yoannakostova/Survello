using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class TextAnswerViewModelMapper
    {
        public static TextAnswerViewModel MapFrom(this TextAnswerDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new TextAnswerViewModel
            {
                Id = dto.Id,
                Answer = dto.Answer,
                TextQuestionId = dto.TextQuestionId
            };
        }

        public static TextAnswerDTO MapFrom(this TextAnswerViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new TextAnswerDTO
            {
                Id = viewModel.Id,
                Answer = viewModel.Answer,
                TextQuestionId = viewModel.TextQuestionId
            };
        }

        public static ICollection<TextAnswerDTO> MapFrom(this ICollection<TextAnswerViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }

        public static ICollection<TextAnswerViewModel> MapFrom(this ICollection<TextAnswerDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
