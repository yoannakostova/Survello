using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class FormViewModelMapper
    {
        public static FormDTO MapFrom(this CreateFormViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new FormDTO
            {
                Id = viewModel.Id,
                DateOfExpiration = viewModel.DateOfExpiration,
                Title = viewModel.Title,
                Description = viewModel.Description,
                UserId = viewModel.UserId,
                MultipleChoiceQuestions = viewModel.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = viewModel.TextQuestions.MapFrom(),
                DocumentQuestions = viewModel.DocumentQuestions.MapFrom()
            };
        }
        public static CreateFormViewModel MapFrom(this FormDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new CreateFormViewModel
            {
                Id = dto.Id,
                DateOfExpiration = dto.DateOfExpiration,
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                MultipleChoiceQuestions = dto.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = dto.TextQuestions.MapFrom(),
                DocumentQuestions = dto.DocumentQuestions.MapFrom()
            };

        }

        public static ICollection<CreateFormViewModel> MapFrom(this ICollection<FormDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }

        public static ICollection<FormDTO> MapFrom(this ICollection<CreateFormViewModel> viewModel)
        {
            return viewModel.Select(MapFrom).ToList();
        }
    }
}
