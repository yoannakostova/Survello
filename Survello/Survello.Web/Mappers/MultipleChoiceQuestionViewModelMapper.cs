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
        public static MultipleChoiceQuestionDTO MapFrom(this MultipleChoiceQuestionViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            ICollection<MultipleChoiceOptionDTO> options = new List<MultipleChoiceOptionDTO>();

            if (viewModel.RadioButtonAnswer != null)
            {
                foreach (var item in viewModel.Options)
                {
                    if (item.Option == viewModel.RadioButtonAnswer)
                    {
                        item.Answer = viewModel.RadioButtonAnswer;
                    }
                }
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

        public static MultipleChoiceQuestionViewModel MapFrom(this MultipleChoiceQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            List<MultipleChoiceOptionViewModel> options = new List<MultipleChoiceOptionViewModel>();

            foreach (var item in dto.Options)
            {
                options.Add(item.MapFrom());
            }

            return new MultipleChoiceQuestionViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                IsRequired = dto.IsRequired,
                IsMultipleAnswer = dto.IsMultipleAnswer,
                Options = options,
                QuestionNumber = dto.QuestionNumber
            };
        }

        public static ICollection<MultipleChoiceQuestionViewModel> MapFrom(this ICollection<MultipleChoiceQuestionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceQuestionDTO> MapFrom(this ICollection<MultipleChoiceQuestionViewModel> viewModels)
        {
            return viewModels.Select(MapFrom).ToList();
        }
    }
}
