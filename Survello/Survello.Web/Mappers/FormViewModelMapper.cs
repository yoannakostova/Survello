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
        public static FormDTO MapFrom(this FormViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new FormDTO
            {
                Id = viewModel.Id,
                CreatedOn = viewModel.CreatedOn,
                LastModifiedOn = viewModel.LastModifiedOn,
                DateOfExpiration = viewModel.DateOfExpiration,
                IsDeleted = viewModel.IsDeleted,
                Title = viewModel.Title,
                Description = viewModel.Description,
                UserId = viewModel.UserId,
                NumberOfFilledForms = viewModel.NumberOfFilledForms,
                MultipleChoiceQuestions = viewModel.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = viewModel.TextQuestions.MapFrom()
            };
        }

        public static FormViewModel MapFrom(this FormDTO dto)
        {
            if (dto == null)
            {
                throw new Exception(ExceptionMessages.EntityNull);
            }

            return new FormViewModel
            {
                Id = dto.Id,
                CreatedOn = dto.CreatedOn,
                LastModifiedOn = dto.LastModifiedOn,
                DateOfExpiration = dto.DateOfExpiration,
                IsDeleted = dto.IsDeleted,
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                NumberOfFilledForms = dto.NumberOfFilledForms,
                MultipleChoiceQuestions = dto.MultipleChoiceQuestions.MapFrom(),
                TextQuestions = dto.TextQuestions.MapFrom()
            };
        }

        public static ICollection<FormViewModel> MapFrom(this ICollection<FormDTO> dtos)
        {
            return dtos.Select(MapFrom).ToList();
        }

        public static ICollection<FormDTO> MapFrom(this ICollection<FormViewModel> viewModel)
        {
            return viewModel.Select(MapFrom).ToList();
        }
    }
}
