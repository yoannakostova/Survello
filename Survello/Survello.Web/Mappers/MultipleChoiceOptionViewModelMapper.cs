using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class MultipleChoiceOptionViewModelMapper
    {
        public static MultipleChoiceOptionViewModel MapFrom(this MultipleChoiceOptionDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceOptionViewModel
            {
                Id = dto.Id,
                Option = dto.Option,
            };
        }

        public static MultipleChoiceOptionDTO MapFrom(this MultipleChoiceOptionViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new MultipleChoiceOptionDTO
            {
                Id = viewModel.Id,
                Option = viewModel.Option,
            };
        }

        public static ICollection<MultipleChoiceOptionDTO> MapFrom(this ICollection<MultipleChoiceOptionViewModel> viewModel)
        {
            return viewModel.Select(MapFrom).ToList();
        }

        public static ICollection<MultipleChoiceOptionViewModel> MapFrom(this ICollection<MultipleChoiceOptionDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }
    }
}
