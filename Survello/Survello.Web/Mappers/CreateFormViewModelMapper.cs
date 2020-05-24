using Survello.Services.ConstantMessages;
using Survello.Services.DTOEntities;
using Survello.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Mappers
{
    public static class CreateFormViewModelMapper
    {
        public static CreateFormDTO MapFrom(this CreateFormViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new CreateFormDTO
            {
                Id = viewModel.Id,
                LastModifiedOn = viewModel.LastModifiedOn,
                DateOfExpiration = viewModel.DateOfExpiration,
                Title = viewModel.Title,
                Description = viewModel.Description,
                UserId = viewModel.UserId,
                NumberOfFilledForms = viewModel.NumberOfFilledForms,
                MultipleChoiceQuestions = viewModel.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = viewModel.TextQuestions.MapFrom(),
                DocumentQuestions = viewModel.DocumentQuestions.MapFrom()
            };
        }
        public static CreateFormViewModel MapFrom(this CreateFormDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new CreateFormViewModel
            {
                Id = dto.Id,
                LastModifiedOn = dto.LastModifiedOn,
                DateOfExpiration = dto.DateOfExpiration,
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                NumberOfFilledForms = dto.NumberOfFilledForms,
                MultipleChoiceQuestions = dto.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = dto.TextQuestions.MapFrom(),
                DocumentQuestions = dto.DocumentQuestions.MapFrom()
            };

        }

        public static ICollection<CreateFormViewModel> MapFrom(this ICollection<CreateFormDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }

        public static ICollection<CreateFormDTO> MapFrom(this ICollection<CreateFormViewModel> viewModel)
        {
            return viewModel.Select(MapFrom).ToList();
        }
    }
}
