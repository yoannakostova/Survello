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

            var dto = new MultipleChoiceQuestionDTO();
            var option = new MultipleChoiceOptionDTO();

            foreach (var item in viewModel.OptionsDescriptions)
            {
                
            }


            return new MultipleChoiceQuestionDTO
            {
                Id = viewModel.Id,
               
            };
        }

        public static MultipleChoiceQuestionViewModel MapFrom(this MultipleChoiceQuestionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceQuestionViewModel
            {
                Id = dto.Id,
                Description = dto.Description,
                IsRequired = dto.IsRequired,
                Options = dto.Options.MapFrom(),
                FormId = dto.FormId,
                FormName = dto.FormName
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
